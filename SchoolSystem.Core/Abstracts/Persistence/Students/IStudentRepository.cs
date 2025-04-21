using SchoolProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Abstracts.Persistence.Students
{
	public interface IStudentRepository : IGenericRepository<Student>
	{
		Task<List<Student>> GetAllStudents();

	}
}
