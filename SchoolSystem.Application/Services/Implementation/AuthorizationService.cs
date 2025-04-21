using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Application.Services._Common;
using SchoolSystem.Application.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Services.Implementation
{
	internal class AuthorizationService : IAuthorizationService
	{
		private readonly RoleManager<IdentityRole> _roleManager;
		public AuthorizationService(RoleManager<IdentityRole> roleManager)
		{
			_roleManager = roleManager;
		}
		public async Task<string> AddRoleAsync(string roleName)
		{
			var exists = await RoleIsExist(roleName);

			if (exists)
				return Status.Exist;

			var role = new IdentityRole(roleName);

			var result = await _roleManager.CreateAsync(role);

			if (result.Succeeded)
				return Status.Success;

			return Status.BadRequest;
		}

		public async Task<string> EditRoleAsync(string id, string newRoleName)
		{
			var role = await _roleManager.FindByIdAsync(id);

			if (role is null)
				return Status.NotFound;

			var exists = await _roleManager.FindByNameAsync(newRoleName);

			if (exists is not null)
				return Status.Exist;

			role.Name = newRoleName;

			var result = await _roleManager.UpdateAsync(role);

			if (result.Succeeded)
				return Status.Success;

			return Status.BadRequest;

		}

		public async Task<string> DeleteRoleAsync(string roleName)
		{
			var role = await _roleManager.FindByNameAsync(roleName);

			if (role is null)
				return Status.NotFound;

			var result = await _roleManager.DeleteAsync(role);

			if (result.Succeeded)
				return Status.Success;

			return Status.BadRequest;
		}

		public async Task<List<string>> GetAllRolesAsync()
		{
			var roles = await _roleManager.Roles.ToListAsync();

			if (roles is null)
				return new List<string>();

			return roles.Select(x => x.Name).ToList()!;
		}

		public async Task<bool> RoleIsExist(string roleName)
		{
			return await _roleManager.RoleExistsAsync(roleName);
		}
	}
}
