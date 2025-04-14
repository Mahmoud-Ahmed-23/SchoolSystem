using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SchoolSystem.Data.Entities.Identity;
using SchoolSystem.Data.Helpers;
using SchoolSystem.Service._Common;
using SchoolSystem.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Service.Implementation
{
	internal class AuthenticationService(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signIn, JwtSettings _jwtSettings) : IAuthenticationService
	{
		public async Task<string> GenerateTokenAsync(ApplicationUser user)
		{
			var userClaims = await _userManager.GetClaimsAsync(user);

			var userRoles = await _userManager.GetRolesAsync(user);

			var rolesAsClaims = new List<Claim>();

			foreach (var role in userRoles)
				rolesAsClaims.Add(new Claim(ClaimTypes.Role, role));



			var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.PrimarySid, user.Id!),
				new Claim(ClaimTypes.MobilePhone,user.PhoneNumber!),
				new Claim(ClaimTypes.Email,user.Email!)
			}
			.Union(userClaims)
			.Union(rolesAsClaims);

			var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

			var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: _jwtSettings.Issuer,
				audience: _jwtSettings.Audience,
				expires: DateTime.Now.AddDays(_jwtSettings.DurationInDays),
				claims: claims,
				signingCredentials: credentials
			);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public async Task<string> SignInAsync(string email, string password)
		{
			var user = await _userManager.FindByEmailAsync(email);
			if (user is null)
				return Status.NotFound;

			var result = await _signIn.CheckPasswordSignInAsync(user, password, false);



			if (!user.EmailConfirmed)
				return Status.EmailNotConfirmed;

			else if (result.IsLockedOut)
				return Status.LockedOut;

			if (!result.Succeeded)
				return Status.InvalidPassword;
			else
			{
				var token = await GenerateTokenAsync(user);
				return token;
			}

		}
	}
}
