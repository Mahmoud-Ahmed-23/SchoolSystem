using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.Specifications._SpecParams.Students
{
	public class StudentSpecParams
	{
		private string? search;

		const int MaxPageSize = 10;

		private int pageSize = 5;



		public string? Sort { get; set; }
		public int? DepartmentId { get; set; }
		public int PageIndex { get; set; } = 1;

		public string? Search
		{
			get { return search; }
			set { search = value?.ToUpper(); }
		}




		public int PageSize
		{
			get { return pageSize; }
			set { pageSize = value > MaxPageSize ? MaxPageSize : value; }
		}

	}
}
