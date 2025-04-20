using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.Specifications._SpecParams
{
	public class Pagination<TEntity>
	{
		public int PageIndex { get; set; } = 1;
		public int PageSize { get; set; } = 5;
		public int Count { get; set; }
		public required IEnumerable<TEntity> Data { get; set; }

		public Pagination(int pageIndex, int pageSize, int count)
		{
			PageIndex = pageIndex;
			PageSize = pageSize;
			Count = count;
		}
	}
}
