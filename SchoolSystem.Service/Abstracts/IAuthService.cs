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
	}
}
