using SchoolSystem.Core.Abstracts.Persistence.Departments;
using SchoolSystem.Core.Abstracts.Persistence.Students;

namespace SchoolSystem.Core.Abstracts.Persistence
{
	public interface IUnitOfWork : IAsyncDisposable
	{

		IStudentRepository StudentRepository { get; }

		IDepartmentRepository DepartmentRepository { get; }

		IGenericRepository<T> GetRepository<T>() where T : class;

		Task<int> CompleteAsync();
	}
}
