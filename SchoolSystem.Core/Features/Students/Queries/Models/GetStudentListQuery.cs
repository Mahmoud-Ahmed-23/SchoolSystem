using MediatR;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Students.Queries.Models
{
	public class GetStudentListQuery : IRequest<List<Student>>
	{

	}
}
