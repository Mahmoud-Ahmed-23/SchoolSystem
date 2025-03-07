using MediatR;
using SchoolSystem.Core.Bases;
using SchoolSystem.Core.Features.Students.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Students.Queries.Models
{
	public class GetStudentByIdQuery : IRequest<Response<ReturnStudentResponse>>
	{
		public int Id { get; set; }
		public GetStudentByIdQuery(int id)
		{
			Id = id;
		}
	}
}
