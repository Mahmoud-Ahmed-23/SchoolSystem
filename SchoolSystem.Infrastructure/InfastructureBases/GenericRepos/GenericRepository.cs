﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolSystem.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.InfastructureBases.GenericRepos
{
	internal class GenericRepository<T>(SchoolDbContext _dbContext) : IGenericRepository<T> where T : class
	{
		public virtual async Task<T> GetByIdAsync(int id)
		{

			return await _dbContext.Set<T>().FindAsync(id);
		}


		public IQueryable<T> GetTableNoTracking()
		{
			return _dbContext.Set<T>().AsNoTracking().AsQueryable();
		}


		public virtual async Task AddRangeAsync(ICollection<T> entities)
		{
			await _dbContext.Set<T>().AddRangeAsync(entities);

		}
		public virtual async Task<T> AddAsync(T entity)
		{
			await _dbContext.Set<T>().AddAsync(entity);

			return entity;
		}

		public virtual async Task UpdateAsync(T entity)
		{
			_dbContext.Set<T>().Update(entity);

		}

		public virtual async Task DeleteAsync(T entity)
		{
			_dbContext.Set<T>().Remove(entity);
		}
		public virtual async Task DeleteRangeAsync(ICollection<T> entities)
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

		public IQueryable<T> GetTableAsTracking()
		{
			return _dbContext.Set<T>().AsQueryable();

		}

		public virtual async Task UpdateRangeAsync(ICollection<T> entities)
		{
			_dbContext.Set<T>().UpdateRange(entities);
		}
	}
}
