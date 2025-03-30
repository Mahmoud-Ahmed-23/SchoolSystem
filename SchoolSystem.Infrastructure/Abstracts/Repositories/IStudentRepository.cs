using SchoolProject.Data.Entities;
using SchoolSystem.Infrastructure.InfastructureBases.GenericRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.Abstracts.Repositories
{
	public interface IStudentRepository : IGenericRepository<Student>
	{
		Task<List<Student>> GetAllStudents();

	}
}
