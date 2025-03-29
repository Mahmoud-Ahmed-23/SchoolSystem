using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Data.Entities;
using SchoolSystem.Core._SharedResources;
using SchoolSystem.Core.Bases;
using SchoolSystem.Core.Features.Students.Commands.Models;
using SchoolSystem.Core.Features.Students.Results;
using SchoolSystem.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Students.Commands.Handlers
{
	public class StudentCommandHandler :
		ResponseHandler,
		IRequestHandler<AddStudentCommand, Response<string>>,
		IRequestHandler<EditStudentCommand, Response<string>>,
		IRequestHandler<DeleteStudentCommand, Response<string>>
	{
		private readonly IStudentService _studentService;
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharedResources> _localizer;

		public StudentCommandHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
		{
			_studentService = studentService;
			_mapper = mapper;
			_localizer = localizer;
		}
		public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
		{
			var student = _mapper.Map<Student>(request);

			var result = await _studentService.AddStudent(student);

			if (result == "Success")
				return Created(string.Empty);
			return BadRequest<string>();
		}

		public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
		{
			var student = await _studentService.GetStudentById(request.Id);

			if (student is null)
				return NotFound<string>();

			var ExistCheck = await _studentService.GetNameIfExistExcludeItSelf(request.Name!, request.Id);

			if (ExistCheck)
				return BadRequest<string>();

			var mappedStudent = _mapper.Map(request, student);

			var result = await _studentService.UpdateStudent(mappedStudent);

			if (result == "Success")
				return Success("");
			return BadRequest<string>();
		}

		public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
		{
			var student = await _studentService.GetStudentById(request.Id);

			if (student is null)
				return NotFound<string>();

			var result = await _studentService.DeleteStudent(student);

			if (result == "Success")
				return Deleted<string>();
			return Deleted<string>();

		}
	}
}
