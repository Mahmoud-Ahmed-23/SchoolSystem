using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Data.Entities;
using SchoolSystem.Core._SharedResources;
using SchoolSystem.Core.Bases;
using SchoolSystem.Core.Features.Students.Queries.Models;
using SchoolSystem.Core.Features.Students.Results;
using SchoolSystem.Infrastructure.Specifications._SpecParams;
using SchoolSystem.Infrastructure.Specifications.Students;
using SchoolSystem.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Students.Queries.Handlers
{
	public class StudentQueryHandler :
		ResponseHandler,
		IRequestHandler<GetStudentListQuery, Response<List<ReturnStudentResponse>>>,
		IRequestHandler<GetStudentByIdQuery, Response<ReturnStudentResponse>>,
		IRequestHandler<GetPaginatedStudentListQuery, Response<Pagination<ReturnStudentResponse>>>
	{
		private readonly IStudentService _studentService;
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharedResources> _localizer;

		public StudentQueryHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
		{
			_studentService = studentService;
			_mapper = mapper;
			_localizer = localizer;
		}

		public async Task<Response<List<ReturnStudentResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
		{
			var students = await _studentService.GetStudentsList();

			var mappedStudents = _mapper.Map<List<ReturnStudentResponse>>(students);

			var result = Success(mappedStudents);

			result.Meta = new
			{
				TotalCount = mappedStudents.Count
			};
			return result;
		}

		public async Task<Response<ReturnStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
		{
			var student = await _studentService.GetStudentById(request.Id);

			if (student is null)
				return NotFound<ReturnStudentResponse>();
			var mappedStudent = _mapper.Map<ReturnStudentResponse>(student);

			var result = Success(mappedStudent);

			result.Meta = new
			{
				TotalCount = 1
			};

			return result;
		}

		public async Task<Response<Pagination<ReturnStudentResponse>>> Handle(GetPaginatedStudentListQuery request, CancellationToken cancellationToken)
		{
			var students = await _studentService.GetPaginatedStudentsList(request.specParams);

			var mappedStudents = _mapper.Map<Pagination<ReturnStudentResponse>>(students);

			var result = Success(mappedStudents);

			result.Meta = new
			{
				TotalCount = mappedStudents.Count
			};
			return result;
		}
	}
}
