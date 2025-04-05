using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.APIs.Bases;
using SchoolSystem.Core.Features.Accounts.Commands.Models;
using SchoolSystem.Core.Features.Accounts.Queries.Models;
using SchoolSystem.Core.Features.Accounts.Results;
using SchoolSystem.Data.AppMetaData;

namespace SchoolSystem.APIs.Controllers.Accounts
{

	public class AccountController : BaseApiController
	{

		[HttpPost(Router.AccountRouting.register)]
		public async Task<ActionResult<string>> Register([FromBody] AddUserCommand command)
		{
			var result = await mediator.Send(command);
			return NewResult(result);
		}
		[HttpPut(Router.AccountRouting.ChangePassword)]
		public async Task<ActionResult<string>> ChangePassword([FromBody] ChangePasswordCommand command)
		{
			var result = await mediator.Send(command);
			return NewResult(result);
		}


	}
}
