using SchoolSystem.Infrastructure.Abstracts;
using SchoolSystem.Infrastructure.Abstracts.Repositories;
using SchoolSystem.Infrastructure.DbContexts;
using SchoolSystem.Infrastructure.InfastructureBases.GenericRepos;
using SchoolSystem.Infrastructure.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.UnitOfwork
{
	internal class UnitOfWork : IUnitOfWork
	{

		private readonly Lazy<IStudentRepository> _studentRepository;
		private readonly Lazy<IDepartmentRepository> _departmentRepository;
		private readonly SchoolDbContext _dbContext;
		private readonly ConcurrentDictionary<string, object> _repositories;
		public UnitOfWork(SchoolDbContext dbContext)
		{
			_dbContext = dbContext;
			_repositories = new ConcurrentDictionary<string, object>();
			_studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(dbContext));
			_departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(dbContext));
		}

		public IStudentRepository StudentRepository => _studentRepository.Value;

		public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;

		public async Task<int> CompleteAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}

		public async ValueTask DisposeAsync()
		{
			await _dbContext.DisposeAsync();
		}

		public IGenericRepository<T> GetRepository<T>() where T : class
		{
			return (IGenericRepository<T>)_repositories.GetOrAdd(typeof(T).Name, new GenericRepository<T>(_dbContext));
		}
	}
}
