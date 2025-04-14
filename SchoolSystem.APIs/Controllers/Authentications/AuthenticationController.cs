using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.APIs.Bases;
using SchoolSystem.Core.Features.Authentication.Commands.Models;
using SchoolSystem.Data.AppMetaData;

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
	}
}
