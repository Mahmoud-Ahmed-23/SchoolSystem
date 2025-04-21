using SchoolProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Specifications.Students
{
	public class StudentSpecForCountSpecifications : BaseSpecifications<Student>
	{
		public StudentSpecForCountSpecifications(int? departmentId, string? search)
			: base(x =>
						(string.IsNullOrEmpty(search) || search.Contains(x.NameEn!) || search.Contains(x.NameAr!))
						&&
						(!departmentId.HasValue || x.DepartmentId == departmentId.Value)
				  )
		{

		}
	}
}
