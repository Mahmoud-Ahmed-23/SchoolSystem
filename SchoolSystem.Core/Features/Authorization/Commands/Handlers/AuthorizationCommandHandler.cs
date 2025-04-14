using MediatR;
using Microsoft.Extensions.Localization;
using SchoolSystem.Core._SharedResources;
using SchoolSystem.Core.Bases;
using SchoolSystem.Core.Features.Authorization.Commands.Models;
using SchoolSystem.Service._Common;
using SchoolSystem.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Authorization.Commands.Handlers
{
	public class AuthorizationCommandHandler
		: ResponseHandler,
		IRequestHandler<AddRoleCommand, Response<string>>,
		IRequestHandler<EditRoleCommand, Response<string>>,
		IRequestHandler<DeleteRoleCommand, Response<string>>
	{
		private readonly IAuthorizationService _authorizationService;
		private readonly IStringLocalizer<SharedResources> _localizer;

		public AuthorizationCommandHandler(IAuthorizationService authorizationService, IStringLocalizer<SharedResources> localizer)
			: base(localizer)
		{
			_authorizationService = authorizationService;
			_localizer = localizer;
		}

		public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
		{
			var result = await _authorizationService.AddRoleAsync(request.RoleName);

			if (result == Status.Success)
				return Success<string>(_localizer[SharedResourcesKeys.Created]);

			return BadRequest<string>(_localizer[SharedResourcesKeys.BadRequest]);
		}

		public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
		{
			var result = await _authorizationService.EditRoleAsync(request.Id, request.NewRoleName);

			if (result == Status.Success)
				return Success<string>(_localizer[SharedResourcesKeys.Updated]);

			else if (result == Status.NotFound)
				return NotFound<string>(_localizer[SharedResourcesKeys.NotFound]);

			else if (result == Status.Exist)
				return BadRequest<string>(_localizer[SharedResourcesKeys.RoleAlreadyExist]);


			return BadRequest<string>(_localizer[SharedResourcesKeys.BadRequest]);
		}

		public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
		{
			var result = await _authorizationService.DeleteRoleAsync(request.roleName);

			if (result == Status.Success)
				return Success<string>(_localizer[SharedResourcesKeys.Deleted]);

			else if (result == Status.NotFound)
				return NotFound<string>(_localizer[SharedResourcesKeys.NotFound]);

			return BadRequest<string>(_localizer[SharedResourcesKeys.BadRequest]);
		}
	}
}
