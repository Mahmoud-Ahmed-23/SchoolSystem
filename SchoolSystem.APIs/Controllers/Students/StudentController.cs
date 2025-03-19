using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Data.Entities;
using SchoolSystem.APIs.Bases;
using SchoolSystem.Core.Features.Students.Commands.Models;
using SchoolSystem.Core.Features.Students.Queries.Models;
using SchoolSystem.Core.Features.Students.Results;
using SchoolSystem.Data.AppMetaData;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolSystem.APIs.Controllers.Students
{
	public class StudentController : BaseApiController
	{



		[HttpGet(Router.StudentRouting.list)]
		public async Task<ActionResult<List<ReturnStudentResponse>>> GetStudentList()
		{
			var result = await mediator.Send(new GetStudentListQuery());
			return NewResult(result);
		}

		[HttpGet(Router.StudentRouting.id)]
		public async Task<ActionResult<ReturnStudentResponse>> GetStudentById([FromRoute] int id)
		{
			var result = await mediator.Send(new GetStudentByIdQuery(id));
			return NewResult(result);
		}

		[HttpPost(Router.StudentRouting.add)]
		public async Task<ActionResult<string>> AddStudent([FromBody] AddStudentCommand student)
		{
			var result = await mediator.Send(student);
			return NewResult(result);
		}
		[HttpPut(Router.StudentRouting.Edit)]
		public async Task<ActionResult<string>> EditStudent([FromBody] EditStudentCommand student)
		{
			var result = await mediator.Send(student);
			return NewResult(result);
		}
		[HttpDelete(Router.StudentRouting.Delete)]
		public async Task<ActionResult<string>> DeleteStudent([FromRoute] int id)
		{
			var result = await mediator.Send(new DeleteStudentCommand(id));
			return NewResult(result);
		}
	}
}
