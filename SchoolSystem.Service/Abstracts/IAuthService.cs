using SchoolSystem.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Service.Abstracts
{
	public interface IAuthService
	{
		Task<string> AddUserAsync(ApplicationUser user, string password);
		Task<ApplicationUser> GetUserByIdAsync(string id);
		Task<string> DeleteUserAsync(string id);
		Task<string> ChangePasswordAsync(string id, string oldPassword, string newPassword);
		bool IsEmailExistExcludeSelf(string email, string id);
		bool IsPhoneExistExcludeSelf(string email, string id);


		//Task<string> EditUserByAdmin(ApplicationUser user);
	}
}
