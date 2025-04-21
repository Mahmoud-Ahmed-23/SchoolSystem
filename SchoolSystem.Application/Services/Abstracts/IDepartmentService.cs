using SchoolProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Services.Abstracts
{
	public interface IDepartmentService
	{
		Task<List<Department>> GetAllDepartments();

		Task<Department> GetDepartmentById(int id);

		Task<string> AddDepartment(Department department);

		Task<string> UpdateDepartment(Department department);

		Task<string> DeleteDepartment(Department department);
	}
}
