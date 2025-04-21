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
		Task<string> SignInAsync(string email, string password);
	}
}
