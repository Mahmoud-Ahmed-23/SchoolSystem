using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SchoolSystem.Core.Entities.Identity;
using SchoolSystem.Core.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Application.Services._Common;
using SchoolSystem.Application.Services.Abstracts;
using SchoolSystem.Application.Dtos;
using Newtonsoft.Json.Linq;

namespace SchoolSystem.Application.Services.Implementation
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

		private RefreshToken GenerateRefreshToken()
		{
			var randomNumber = new byte[32];

			var generator = RandomNumberGenerator.Create();

			generator.GetBytes(randomNumber);

			return new RefreshToken
			{
				Token = Convert.ToBase64String(randomNumber),
				CreatedOn = DateTime.UtcNow,
				ExpireOn = DateTime.UtcNow.AddDays(_jwtSettings.JWTRefreshTokenExpire)
			};
		}

		private async Task CheckRefreshToken(UserManager<ApplicationUser> userManager, ApplicationUser user, UserDto response)
		{
			if (user.RefreshTokens.Any(x => x.IsActive))
			{
				var oldRefreshToken = user.RefreshTokens.FirstOrDefault(x => x.IsActive);

				if (oldRefreshToken is null)
					return;

				response.RefreshToken = oldRefreshToken.Token;
				response.RefreshTokenExpiryTime = oldRefreshToken.ExpireOn;
			}
			else
			{
				var newRefreshToken = GenerateRefreshToken();

				response.RefreshToken = newRefreshToken.Token;

				response.RefreshTokenExpiryTime = newRefreshToken.ExpireOn;

				user.RefreshTokens.Add(newRefreshToken);

				await userManager.UpdateAsync(user);
			}
		}

		private string? ValidateToken(string token)
		{
			var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
			var tokenHandler = new JwtSecurityTokenHandler();
			try
			{
				var validationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = authKey,
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = false,
					ClockSkew = TimeSpan.Zero
				};

				var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

				var jwtToken = validatedToken as JwtSecurityToken;

				if (jwtToken != null)
				{
					var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value;

					if (userId != null)
						return userId;
					return null;
				}
				return null;
			}
			catch
			{
				return null;
			}
		}

		public async Task<UserDto> GetRefreshToken(RefreshDto refreshDto)
		{
			var userId = ValidateToken(refreshDto.Token);

			if (userId is null)
				return new UserDto
				{
					Status = Status.NotFound
				};

			var user = await _userManager.FindByIdAsync(userId);

			if (user is null)
				return new UserDto
				{
					Status = Status.NotFound
				};

			var refreshToken = user.RefreshTokens.FirstOrDefault(x => x.Token == refreshDto.RefreshToken && x.IsActive);

			if (refreshToken is null)
				return new UserDto
				{
					Status = Status.TokenNotFound
				};

			refreshToken.RevokedOn = DateTime.UtcNow;

			var newToken = await GenerateTokenAsync(user);

			var newRefreshToken = GenerateRefreshToken();

			user.RefreshTokens.Add(newRefreshToken);

			await _userManager.UpdateAsync(user);

			var userDto = new UserDto
			{
				FullName = user.FullName,
				Status = Status.Success,
				Email = user.Email!,
				Id = user.Id,
				PhoneNumber = user.PhoneNumber!,
				Token = newToken,
				RefreshToken = newRefreshToken.Token,
				RefreshTokenExpiryTime = newRefreshToken.ExpireOn
			};

			return userDto;

		}

		public async Task<bool> RevokeRefreshToken(RefreshDto refreshDto)
		{
			var userId = ValidateToken(refreshDto.Token);

			if (userId is null)
				return false;

			var user = await _userManager.FindByIdAsync(userId);

			if (user is null)
				return false;

			var refreshToken = user.RefreshTokens.FirstOrDefault(x => x.Token == refreshDto.RefreshToken && x.IsActive);

			if (refreshToken is null)
				return false;

			refreshToken.RevokedOn = DateTime.UtcNow;

			await _userManager.UpdateAsync(user);

			return true;
		}

		public async Task<UserDto> SignInAsync(string email, string password)
		{
			var user = await _userManager.FindByEmailAsync(email);
			if (user is null)
			{
				return new UserDto
				{
					Status = Status.NotFound
				};
			}

			var result = await _signIn.CheckPasswordSignInAsync(user, password, false);


			if (!user.EmailConfirmed)
				return new UserDto
				{
					Status = Status.EmailNotConfirmed
				};

			else if (result.IsLockedOut)

				return new UserDto
				{
					Status = Status.LockedOut
				};

			if (!result.Succeeded)
				return new UserDto
				{
					Status = Status.InvalidPassword
				};

			else
			{
				var token = await GenerateTokenAsync(user);

				var userDto = new UserDto
				{
					FullName = user.FullName,
					Status = Status.Success,
					Email = user.Email!,
					Id = user.Id,
					PhoneNumber = user.PhoneNumber!,
					Token = token
				};

				await CheckRefreshToken(_userManager, user, userDto);

				return userDto;
			}

		}
	}
}
