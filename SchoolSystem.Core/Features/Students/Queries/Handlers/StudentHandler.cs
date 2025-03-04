using MediatR;
using SchoolProject.Data.Entities;
using SchoolSystem.Core.Features.Students.Queries.Models;
using SchoolSystem.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Students.Queries.Handlers
{
	public class StudentHandler(IStudentService studentService) : IRequestHandler<GetStudentListQuery, List<Student>>
	{
		public async Task<List<Student>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
		{
			var students = await studentService.GetStudentsList();

			return students;
		}
	}
}
