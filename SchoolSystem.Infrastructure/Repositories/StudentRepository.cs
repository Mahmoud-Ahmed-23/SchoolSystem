using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Entities;
using SchoolSystem.Core.Abstracts.Persistence.Students;
using SchoolSystem.Infrastructure.Persistence.DbContexts;
using SchoolSystem.Infrastructure.Persistence.InfastructureBases.GenericRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.Repositories
{
	internal class StudentRepository : GenericRepository<Student>, IStudentRepository
	{
		private readonly SchoolDbContext _dbContext;


		public StudentRepository(SchoolDbContext dbContext)
			: base(dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<List<Student>> GetAllStudents()
		=> await _dbContext.Students.Include(d => d.Department).ToListAsync();
	}
}
