using AutoMapper;
using MediatR;
using SchoolProject.Data.Entities;
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
	public class StudentCommandHandler(IStudentService studentService, IMapper mapper) :
		ResponseHandler,
		IRequestHandler<AddStudentCommand, Response<string>>,
		IRequestHandler<EditStudentCommand, Response<string>>,
		IRequestHandler<DeleteStudentCommand, Response<string>>
	{
		public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
		{
			var student = mapper.Map<Student>(request);

			var result = await studentService.AddStudent(student);

			if (result == "Success")
				return Created("Student is Created");
			return BadRequest<string>("Student is not Created");
		}

		public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
		{
			var student = await studentService.GetStudentById(request.Id);

			if (student is null)
				return NotFound<string>("Student is not Found");

			var ExistCheck = await studentService.GetNameIfExistExcludeItSelf(request.Name!, request.Id);

			if (ExistCheck)
				return BadRequest<string>("Name is already used please choose another name");

			var mappedStudent = mapper.Map(request, student);

			var result = await studentService.UpdateStudent(mappedStudent);

			if (result == "Success")
				return Success($"Update Student {mappedStudent.Name} is Successfully");
			return BadRequest<string>($"Update Student {mappedStudent.Name} is Failed");
		}

		public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
		{
			var student = await studentService.GetStudentById(request.Id);

			if (student is null)
				return NotFound<string>("Student is not Found");

			var result = await studentService.DeleteStudent(student);

			if (result == "Success")
				return Deleted<string>($"Delete Student {student.Name} is Successfully");
			return Deleted<string>($"Delete Student {student.Name} is Failed");

		}
	}
}
