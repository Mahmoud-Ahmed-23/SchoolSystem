using AutoMapper;
using MediatR;
using SchoolProject.Data.Entities;
using SchoolSystem.Core.Features.Students.Queries.Models;
using SchoolSystem.Core.Features.Students.Results;
using SchoolSystem.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Students.Queries.Handlers
{
	public class StudentHandler(IStudentService studentService, IMapper mapper) : IRequestHandler<GetStudentListQuery, List<GetStudentListResponse>>
	{
		public async Task<List<GetStudentListResponse>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
		{
			var students = await studentService.GetStudentsList();

			var mappedStudents = mapper.Map<List<GetStudentListResponse>>(students);

			return mappedStudents;
		}
	}
}
