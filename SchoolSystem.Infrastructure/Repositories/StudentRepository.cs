using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolSystem.Infrastructure.Abstracts.Repositories;
using SchoolSystem.Infrastructure.DbContexts;
using SchoolSystem.Infrastructure.InfastructureBases.GenericRepos;
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
