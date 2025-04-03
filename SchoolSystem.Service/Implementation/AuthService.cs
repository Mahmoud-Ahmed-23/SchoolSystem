using Microsoft.AspNetCore.Identity;
using SchoolSystem.Data.Entities.Identity;
using SchoolSystem.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Service.Implementation
{
	internal class AuthService(UserManager<ApplicationUser> _userManager) : IAuthService
	{




		public async Task<string> AddUserAsync(ApplicationUser user, string password)
		{
			var findUser = await _userManager.FindByEmailAsync(user.Email!);

			if (findUser is not null)
				return "User is already Exist";

			user.UserName = user.Email;

			var result = await _userManager.CreateAsync(user, password);

			if (result.Succeeded)
				return "Success";
			else
			{
				var errors = result.Errors.Select(e => e.Description).ToList();
				return string.Join(", ", errors);
			}
		}

	}
}
