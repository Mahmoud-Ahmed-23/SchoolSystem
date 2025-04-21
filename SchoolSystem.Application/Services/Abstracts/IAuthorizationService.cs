using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Services.Abstracts
{
	public interface IAuthorizationService
	{
		public Task<string> AddRoleAsync(string roleName);
		public Task<string> EditRoleAsync(string id, string newRoleName);
		public Task<string> DeleteRoleAsync(string roleName);
		public Task<List<string>> GetAllRolesAsync();
		Task<bool> RoleIsExist(string roleName);
	}
}
