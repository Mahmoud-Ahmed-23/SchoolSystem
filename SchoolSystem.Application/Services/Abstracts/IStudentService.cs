using SchoolProject.Core.Entities;
using SchoolSystem.Application.Services._Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Services.Abstracts
{
	public interface IStudentService
	{
		Task<List<Student>> GetStudentsList();

		Task<Student> GetStudentById(int id);

		Task<string> AddStudent(Student student);

		Task<string> UpdateStudent(Student student);

		Task<string> DeleteStudent(Student student);

		Task<bool> GetNameIfExistExcludeItSelf(string name, int id);

		Task<Pagination<Student>> GetPaginatedStudentsList(StudentSpecParams specParams);

	}
}
