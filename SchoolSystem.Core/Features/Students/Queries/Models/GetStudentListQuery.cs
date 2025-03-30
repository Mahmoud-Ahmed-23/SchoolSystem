using MediatR;
using SchoolProject.Data.Entities;
using SchoolSystem.Core.Bases;
using SchoolSystem.Core.Features.Students.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Students.Queries.Models
{
	public class GetStudentListQuery : IRequest<Response<List<ReturnStudentResponse>>> 
	{

	}
}
