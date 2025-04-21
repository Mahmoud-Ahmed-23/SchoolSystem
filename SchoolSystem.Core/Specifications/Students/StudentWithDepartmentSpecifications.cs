using SchoolProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Specifications.Students
{
	public class StudentWithDepartmentSpecifications : BaseSpecifications<Student>
	{
		public StudentWithDepartmentSpecifications(string? sort, int? departmentId, int pageIndex, int pageSize, string? search)
			: base(x =>
						(string.IsNullOrEmpty(search) || search.Contains(x.NameEn!) || search.Contains(x.NameAr!))
						&&
						(!departmentId.HasValue || x.DepartmentId == departmentId.Value)
				  )
		{
			AddInclude();

			switch (sort)
			{
				case "NameEn":
					AddOrder(x => x.NameEn!);
					break;

				case "NameEnDesc":
					AddOrderDescending(x => x.NameEn!);
					break;

				case "NameAr":
					AddOrder(x => x.NameAr!);
					break;

				case "NameArDesc":
					AddOrder(x => x.NameAr!);
					break;
			}

			ApplyPagination((pageIndex - 1) * pageSize, pageSize);
		}
		
		private protected override void AddInclude()
		{
			base.AddInclude();
			Includes.Add(x => x.Department!);
		}
	}
}
