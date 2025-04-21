using MediatR;
using SchoolProject.Core.Entities;
using SchoolSystem.Application.Bases;
using SchoolSystem.Application.Features.Students.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Features.Students.Queries.Models
{
	public class GetStudentListQuery : IRequest<Response<List<ReturnStudentResponse>>> 
	{

	}
}
