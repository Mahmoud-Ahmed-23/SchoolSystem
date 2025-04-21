using Microsoft.EntityFrameworkCore.Storage;
using SchoolSystem.Core.Abstracts.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Abstracts.Persistence
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		Task DeleteRangeAsync(ICollection<TEntity> entities);
		Task<TEntity> GetByIdAsync(int id);
		IDbContextTransaction BeginTransaction();
		void Commit();
		void RollBack();
		IQueryable<TEntity> GetTableNoTracking();
		IQueryable<TEntity> GetTableAsTracking();
		Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity> specifications);
		Task<int> GetCountAsync(ISpecifications<TEntity> spec);
		Task<TEntity> AddAsync(TEntity entity);
		Task AddRangeAsync(ICollection<TEntity> entities);
		Task UpdateAsync(TEntity entity);
		Task UpdateRangeAsync(ICollection<TEntity> entities);
		Task DeleteAsync(TEntity entity);
	}
}
