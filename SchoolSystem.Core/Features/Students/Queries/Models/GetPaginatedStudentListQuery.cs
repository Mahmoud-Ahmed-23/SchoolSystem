using MediatR;
using SchoolSystem.Application.Bases;
using SchoolSystem.Application.Features.Students.Results;
using SchoolSystem.Application.Services._Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Features.Students.Queries.Models
{
	public class GetPaginatedStudentListQuery : IRequest<Response<Pagination<ReturnStudentResponse>>>
	{
		public StudentSpecParams specParams { get; set; }

		public GetPaginatedStudentListQuery(StudentSpecParams specParams)
		{
			this.specParams = specParams;
		}


	}
}
