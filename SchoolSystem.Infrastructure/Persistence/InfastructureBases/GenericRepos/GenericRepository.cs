using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolSystem.Core.Abstracts.Persistence;
using SchoolSystem.Core.Abstracts.Specifications;
using SchoolSystem.Infrastructure.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.Persistence.InfastructureBases.GenericRepos
{
	internal class GenericRepository<TEntity>(SchoolDbContext _dbContext)
		: IGenericRepository<TEntity> where TEntity : class
	{
		public virtual async Task<TEntity> GetByIdAsync(int id)
		{

			return await _dbContext.Set<TEntity>().FindAsync(id) ?? null!;
		}


		public IQueryable<TEntity> GetTableNoTracking()
		{
			return _dbContext.Set<TEntity>().AsNoTracking().AsQueryable();
		}


		public async Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity> specifications)
			=> await EvaluateSpecification(specifications).ToListAsync();

		public async Task<int> GetCountAsync(ISpecifications<TEntity> spec)
			=> await EvaluateSpecification(spec).CountAsync();

		private IQueryable<TEntity> EvaluateSpecification(ISpecifications<TEntity> spec)
			=> SpecificationsEvaluator<TEntity>.GetQuery(_dbContext.Set<TEntity>(), spec);

		public virtual async Task AddRangeAsync(ICollection<TEntity> entities)
		{
			await _dbContext.Set<TEntity>().AddRangeAsync(entities);

		}
		public virtual async Task<TEntity> AddAsync(TEntity entity)
		{
			await _dbContext.Set<TEntity>().AddAsync(entity);

			return entity;
		}

		public virtual async Task UpdateAsync(TEntity entity)
		{
			_dbContext.Set<TEntity>().Update(entity);

		}

		public virtual async Task DeleteAsync(TEntity entity)
		{
			_dbContext.Set<TEntity>().Remove(entity);
		}
		public virtual async Task DeleteRangeAsync(ICollection<TEntity> entities)
		{
			foreach (var entity in entities)
			{
				_dbContext.Entry(entity).State = EntityState.Deleted;
			}
		}





		public IDbContextTransaction BeginTransaction()
		{


			return _dbContext.Database.BeginTransaction();
		}

		public void Commit()
		{
			_dbContext.Database.CommitTransaction();

		}

		public void RollBack()
		{
			_dbContext.Database.RollbackTransaction();

		}

		public IQueryable<TEntity> GetTableAsTracking()
		{
			return _dbContext.Set<TEntity>().AsQueryable();

		}

		public virtual async Task UpdateRangeAsync(ICollection<TEntity> entities)
		{
			_dbContext.Set<TEntity>().UpdateRange(entities);
		}


	}
}
