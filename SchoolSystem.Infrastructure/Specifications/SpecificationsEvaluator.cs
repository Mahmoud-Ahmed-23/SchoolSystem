using SchoolSystem.Infrastructure.Abstracts.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.Specifications
{
	public class SpecificationsEvaluator<TEntity> where TEntity : class
	{
		public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecifications<TEntity> specifications)
		{
			var query = inputQuery;

			if (specifications.Criteria is not null)
				query = query.Where(specifications.Criteria);



			if (specifications.OrderByDescending is not null)
				query = query.OrderByDescending(specifications.OrderByDescending);

			else if (specifications.OrderBy is not null)
				query = query.OrderBy(specifications.OrderBy);


			if (specifications.IsPaginated)
				query = query.Skip(specifications.Skip).Take(specifications.Take);


			query = specifications.Includes.Aggregate(query, (current, include) => current.Include(include));

			return query;
		}
	}
}
