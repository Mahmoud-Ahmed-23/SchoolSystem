using MediatR;
using Microsoft.Extensions.Localization;
using SchoolSystem.Core._SharedResources;
using SchoolSystem.Core.Bases;
using SchoolSystem.Core.Features.Authentication.Commands.Models;
using SchoolSystem.Service._Common;
using SchoolSystem.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Authentication.Commands.Handlers
{
	public class AuthenticationCommandHandler :
		ResponseHandler,
		IRequestHandler<SignInCommand, Response<string>>
	{
		private readonly IStringLocalizer<SharedResources> _localizer;
		private readonly IAuthenticationService _authenticationService;
		public AuthenticationCommandHandler(IStringLocalizer<SharedResources> localizer, IAuthenticationService authenticationService)
			: base(localizer)
		{
			_localizer = localizer;
			_authenticationService = authenticationService;
		}

		public async Task<Response<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
		{
			var result = await _authenticationService.SignInAsync(request.Email, request.Password);


			 if (result == Status.NotFound)
				return NotFound<string>(_localizer[SharedResourcesKeys.EmailNotFound]);

			else if (result == Status.LockedOut)
				return BadRequest<string>(_localizer[SharedResourcesKeys.LockedOut]);

			else if (result == Status.InvalidPassword)
				return BadRequest<string>(_localizer[SharedResourcesKeys.InvalidPassword]);


			else if (result == Status.EmailNotConfirmed)
				return BadRequest<string>(_localizer[SharedResourcesKeys.EmailNotConfirmed]);

			else
				return Success(result, _localizer[SharedResourcesKeys.Success]);
		}
	}
}
