using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.APIs.Bases;
using SchoolSystem.Core.Features.Accounts.Commands.Models;
using SchoolSystem.Core.Features.Accounts.Queries.Models;
using SchoolSystem.Core.Features.Accounts.Results;
using SchoolSystem.Data.AppMetaData;

namespace SchoolSystem.APIs.Controllers.Dashboard
{
	public class DashboardController : BaseApiController
	{
		[HttpGet(Router.Dashboard.id)]
		public async Task<ActionResult<ReturnUserResponse>> GetUserById([FromRoute] string id)
		{
			var result = await mediator.Send(new GetUserByIdQuery(id));
			return NewResult(result);
		}

		[HttpPut(Router.Dashboard.Edit)]
		public async Task<ActionResult<string>> EditUserByAdmin([FromBody] EditUserCommand request)
		{
			var result = await mediator.Send(request);
			return NewResult(result);
		}
		[HttpDelete(Router.Dashboard.Delete)]
		public async Task<ActionResult<string>> DeleteUserByAdmin([FromRoute] string id)
		{
			var result = await mediator.Send(new DeleteUserCommand(id));
			return NewResult(result);
		}
	}
}
