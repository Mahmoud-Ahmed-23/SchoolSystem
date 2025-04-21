using SchoolProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Features.Departments.Results
{
	public class ReturnDepartmentResponse
	{
		public string? Name { get; set; }

		public string? ManagerName { get; set; }

	}
}
