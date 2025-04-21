using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.APIs.Bases;
using SchoolSystem.Application.Features.Accounts.Commands.Models;
using SchoolSystem.Application.Features.Accounts.Queries.Models;
using SchoolSystem.Application.Features.Accounts.Results;
using SchoolSystem.Application.Features.Authorization.Commands.Models;
using SchoolSystem.Application.Features.Authorization.Queries.Models;
using SchoolSystem.Core.AppMetaData;

namespace SchoolSystem.APIs.Controllers.Dashboard
{
	[Authorize(Roles = "Admin")]
	public class DashboardController : BaseApiController
	{
		[HttpGet(Router.Dashboard.GetUserid)]
		public async Task<ActionResult<ReturnUserResponse>> GetUserById([FromRoute] string id)
		{
			var result = await mediator.Send(new GetUserByIdQuery(id));
			return NewResult(result);
		}

		[HttpPut(Router.Dashboard.EditUser)]
		public async Task<ActionResult<string>> EditUserByAdmin([FromBody] EditUserCommand request)
		{
			var result = await mediator.Send(request);
			return NewResult(result);
		}
		[HttpDelete(Router.Dashboard.DeleteUser)]
		public async Task<ActionResult<string>> DeleteUserByAdmin([FromRoute] string id)
		{
			var result = await mediator.Send(new DeleteUserCommand(id));
			return NewResult(result);
		}

		[HttpPost(Router.Dashboard.AddRole)]
		public async Task<ActionResult<string>> AddRole([FromForm] string roleName)
		{
			var result = await mediator.Send(new AddRoleCommand(roleName));
			return NewResult(result);
		}

		[HttpPut(Router.Dashboard.EditRole)]
		public async Task<ActionResult<string>> EditRole([FromBody] EditRoleCommand request)
		{
			var result = await mediator.Send(request);
			return NewResult(result);
		}

		[HttpDelete(Router.Dashboard.DeleteRole)]
		public async Task<ActionResult<string>> DeleteRole([FromForm] string roleName)
		{
			var result = await mediator.Send(new DeleteRoleCommand(roleName));
			return NewResult(result);
		}

		[HttpGet(Router.Dashboard.Roleslist)]
		public async Task<ActionResult<List<ReturnUserResponse>>> GetAllRoles()
		{
			var result = await mediator.Send(new GetRolesListQuery());
			return NewResult(result);
		}

	}
}
