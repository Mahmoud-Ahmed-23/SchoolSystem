using SchoolSystem.Application.Dtos;
using SchoolSystem.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Services.Abstracts
{
	public interface IAuthenticationService
	{
		Task<string> GenerateTokenAsync(ApplicationUser user);
		Task<UserDto> SignInAsync(string email, string password);

		Task<UserDto> GetRefreshToken(RefreshDto refreshDto);
		Task<bool> RevokeRefreshToken(RefreshDto refreshDto);
	}
}
