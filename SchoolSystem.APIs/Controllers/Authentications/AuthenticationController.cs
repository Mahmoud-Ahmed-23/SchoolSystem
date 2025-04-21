using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.APIs.Bases;
using SchoolSystem.Application.Features.Authentication.Commands.Models;
using SchoolSystem.Core.AppMetaData;

namespace SchoolSystem.APIs.Controllers.Authentications
{

	public class AuthenticationController : BaseApiController
	{
		[HttpPost(Router.AuthenticationRouting.SignIn)]
		public async Task<ActionResult<string>> SignIn([FromBody] SignInCommand command)
		{
			var result = await mediator.Send(command);
			return NewResult(result);
		}

		[HttpPost(Router.AuthenticationRouting.RefreshToken)]
		public async Task<ActionResult<string>> RefreshToken([FromBody] RefreshTokenCommand command)
		{
			var result = await mediator.Send(command);
			return NewResult(result);
		}
		[HttpPost(Router.AuthenticationRouting.RevokeRefreshToken)]
		public async Task<ActionResult<string>> RevokeRefreshToken([FromBody] RevokeRefreshTokenCommand command)
		{
			var result = await mediator.Send(command);
			return NewResult(result);
		}
	}
}
