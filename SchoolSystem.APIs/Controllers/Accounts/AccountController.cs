using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.APIs.Bases;
using SchoolSystem.Application.Features.Accounts.Commands.Models;
using SchoolSystem.Application.Features.Accounts.Queries.Models;
using SchoolSystem.Application.Features.Accounts.Results;
using SchoolSystem.Application.Features.Emails.Commands.Models;
using SchoolSystem.Core.AppMetaData;

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

		[HttpPost(Router.AccountRouting.SendCode)]
		public async Task<ActionResult<string>> SendCode([FromQuery] string email)
		{
			var result = await mediator.Send(new SendCodeCommand() { Email = email });
			return NewResult(result);
		}

		[HttpPost(Router.AccountRouting.VerfiyCode)]
		public async Task<ActionResult<string>> VerifyCode([FromQuery] string email, [FromQuery] int code)
		{
			var result = await mediator.Send(new VerifyCodeByEmailCommand() { Email = email, resetCode = code });
			return NewResult(result);
		}

		[HttpPut(Router.AccountRouting.ResetPassword)]
		public async Task<ActionResult<string>> ResetPassword([FromBody] ResetPasswordCommand command)
		{
			var result = await mediator.Send(command);
			return NewResult(result);
		}

		[HttpPut(Router.AccountRouting.EmailConfirmation)]
		public async Task<ActionResult<string>> EmailConfirmation([FromQuery] string email, [FromQuery] int code)
		{
			var result = await mediator.Send(new ConfirmEmailCommand() { Email = email, ConfirmationCode = code });
			return NewResult(result);
		}

	}
}
