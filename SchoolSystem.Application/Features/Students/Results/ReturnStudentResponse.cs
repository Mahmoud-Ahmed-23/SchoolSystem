﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Features.Students.Results
{
	public class ReturnStudentResponse
	{
		public string? Name { get; set; }

		public string? Address { get; set; }

		public string? Phone { get; set; }

		public string? DepartmentName { get; set; }

	}
}
