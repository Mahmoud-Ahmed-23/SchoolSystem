using SchoolSystem.Core.Abstracts.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Specifications
{
	public class BaseSpecifications<TEntity> : ISpecifications<TEntity>
	{
		public Expression<Func<TEntity, bool>>? Criteria { get; set; }
		public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new();
		public Expression<Func<TEntity, object>>? OrderBy { get; set; }
		public Expression<Func<TEntity, object>>? OrderByDescending { get; set; }
		public int Skip { get; set; }
		public int Take { get; set; }
		public bool IsPaginated { get; set; }

		public BaseSpecifications()
		{

		}

		public BaseSpecifications(Expression<Func<TEntity, bool>> criteria)
		{
			Criteria = criteria;
		}

		private protected virtual void AddInclude()
		{

		}
		private protected void AddOrder(Expression<Func<TEntity, object>>? orderBy)
		{
			OrderBy = orderBy;
		}
		protected void AddOrderDescending(Expression<Func<TEntity, object>>? orderBy)
		{
			OrderByDescending = orderBy;
		}

		private protected void ApplyPagination(int skip, int take)
		{
			Skip = skip;
			Take = take;
			IsPaginated = true;
		}
	}
}
