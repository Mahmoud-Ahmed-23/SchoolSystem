using MediatR;
using SchoolSystem.Core.Bases;
using SchoolSystem.Core.Features.Students.Results;
using SchoolSystem.Infrastructure.Specifications._SpecParams;
using SchoolSystem.Infrastructure.Specifications._SpecParams.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Students.Queries.Models
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
