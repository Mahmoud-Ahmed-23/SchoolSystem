using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Data.Entities;
using SchoolSystem.Core.Features.Students.Queries.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolSystem.APIs.Controllers.Students
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController(IMediator mediator) : ControllerBase
	{



		[HttpGet("GetStudentList")]
		public async Task<ActionResult<List<Student>>> GetStudentList()
		{
			var result = await mediator.Send(new GetStudentListQuery());
			return Ok(result);
		}
	}
}
