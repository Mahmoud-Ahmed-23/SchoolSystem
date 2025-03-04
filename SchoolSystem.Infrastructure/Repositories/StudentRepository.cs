using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolSystem.Infrastructure.Abstracts;
using SchoolSystem.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.Repositories
{
	internal class StudentRepository(SchoolDbContext dbContext) : IStudentRepository
	{
		public async Task<List<Student>> GetAllStudents()
		=> await dbContext.Students./*Include(d => d.Department).*/ToListAsync();
	}
}
