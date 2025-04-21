using MediatR;
using SchoolSystem.Application.Bases;
using SchoolSystem.Application.Features.Departments.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Features.Departments.Queries.Models
{
	public class GetDepartmentByIdQuery : IRequest<Response<ReturnDepartmentByIdResponse>>
	{
		public int id { get; set; }
		public GetDepartmentByIdQuery(int id)
		{
			this.id = id;
		}
	}
}
