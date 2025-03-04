using SchoolSystem.Infrastructure.Abstracts;
using SchoolSystem.Infrastructure.DbContexts;
using SchoolSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.UnitOfwork
{
	internal class UnitOfWork : IUnitOfWork
	{

		private readonly Lazy<IStudentRepository> _studentRepository;
		private readonly SchoolDbContext _dbContext;

		public UnitOfWork(SchoolDbContext dbContext)
		{
			_dbContext = dbContext;
			_studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(dbContext));
		}

		public IStudentRepository StudentRepository => _studentRepository.Value;

		public async Task<int> CompleteAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}

		public async ValueTask DisposeAsync()
		{
			await _dbContext.DisposeAsync();
		}
	}
}
