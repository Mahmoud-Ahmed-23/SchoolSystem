using AutoMapper;
using MediatR;
using SchoolProject.Data.Entities;
using SchoolSystem.Core.Bases;
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
	public class StudentQueryHandler(IStudentService studentService, IMapper mapper) :
		ResponseHandler,
		IRequestHandler<GetStudentListQuery, Response<List<ReturnStudentResponse>>>,
		IRequestHandler<GetStudentByIdQuery, Response<ReturnStudentResponse>>
	{
		public async Task<Response<List<ReturnStudentResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
		{
			var students = await studentService.GetStudentsList();

			var mappedStudents = mapper.Map<List<ReturnStudentResponse>>(students);

			return Success(mappedStudents);
		}

		public async Task<Response<ReturnStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
		{
			var student = await studentService.GetStudentById(request.Id);

			var mappedStudent = mapper.Map<ReturnStudentResponse>(student);

			return Success(mappedStudent);
		}
	}
}
