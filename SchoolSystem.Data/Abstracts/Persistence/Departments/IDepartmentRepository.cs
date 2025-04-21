using SchoolProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Abstracts.Persistence.Departments
{
	public interface IDepartmentRepository : IGenericRepository<Department>
	{
		Task<List<Department>> GetAllDepartments();
		Task<bool> IsNameExist(Department department);
		Task<bool> IsNameExistExcludeSelf(Department department);
		Task<Department> GetDepartmentById(int id);
	}
}
