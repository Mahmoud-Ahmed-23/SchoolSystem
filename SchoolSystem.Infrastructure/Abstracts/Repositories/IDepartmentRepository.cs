using SchoolProject.Data.Entities;
using SchoolSystem.Infrastructure.InfastructureBases.GenericRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.Abstracts.Repositories
{
	public interface IDepartmentRepository : IGenericRepository<Department>
	{
		Task<List<Department>> GetAllDepartments();
		Task<bool> IsNameExist(Department department);
		Task<bool> IsNameExistExcludeSelf(Department department);
	}
}
