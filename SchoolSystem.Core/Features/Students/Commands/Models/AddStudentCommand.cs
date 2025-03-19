using MediatR;
using SchoolSystem.Core.Bases;
using SchoolSystem.Core.Features.Students.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Students.Commands.Models
{
	public class AddStudentCommand : IRequest<Response<string>>
	{
		public string Name { get; set; }


		public string Address { get; set; }


		public string? Phone { get; set; }


		public int? DepartmentId { get; set; }
		public AddStudentCommand(string Name, string Address, string? Phone, int? DepartmentId)
		{
			this.Name = Name;
			this.Address = Address;
			this.Phone = Phone;
			this.DepartmentId = DepartmentId;
		}
	}
}
