using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
	internal class AuthService(UserManager<ApplicationUser> _userManager,JwtSettings _jwtSettings) : IAuthService
	{




		public async Task<string> AddUserAsync(ApplicationUser user, string password)
		{
			var findUser = await _userManager.FindByEmailAsync(user.Email!);

			if (findUser is not null)
				return Status.Exist;

			user.UserName = user.Email;

			var result = await _userManager.CreateAsync(user, password);

			if (result.Succeeded)
				return Status.Success;
			else
			{
				var errors = result.Errors.Select(e => e.Description).ToList();
				return string.Join(", ", errors);
			}
		}


		public async Task<ApplicationUser> GetUserByIdAsync(string id)
		{
			var user = await _userManager.FindByIdAsync(id);

			if (user is null)
				throw new UnauthorizedAccessException(Status.NotFound);

			return user;
		}


		public async Task<string> DeleteUserAsync(string id)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user is null)
				return Status.NotFound;
			var result = _userManager.DeleteAsync(user).Result;

			if (result.Succeeded)
				return Status.Success;
			else
			{
				var errors = result.Errors.Select(e => e.Description).ToList();
				return string.Join(", ", errors);
			}
		}


		public bool IsEmailExistExcludeSelf(string email, string id)
		{
			var findUser = _userManager.Users.Where(x => x.NormalizedEmail == email.ToUpper() && x.Id != id).FirstOrDefault();


			if (findUser is not null)
				return true;

			return false;
		}

		public bool IsPhoneExistExcludeSelf(string phone, string id)
		{
			var findUser = _userManager.Users.Where(x => x.PhoneNumber == phone && x.Id != id).FirstOrDefault();


			if (findUser is not null)
				return true;

			return false;
		}

		public async Task<string> ChangePasswordAsync(string id, string oldPassword, string newPassword)
		{
			var user = await _userManager.FindByIdAsync(id);

			if (user is null)
				return Status.NotFound;


			var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);


			if (result.Succeeded)
				return Status.Success;
			else
			{
				var errors = result.Errors.Select(e => e.Description).ToList();
				return string.Join(", ", errors);
			}
		}

		
	}
}
