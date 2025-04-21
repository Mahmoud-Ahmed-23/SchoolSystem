using MediatR;
using Microsoft.Extensions.Localization;
using SchoolSystem.Application._SharedResources;
using SchoolSystem.Application.Bases;
using SchoolSystem.Application.Features.Authentication.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Application.Services._Common;
using SchoolSystem.Application.Services.Abstracts;
using SchoolSystem.Application.Dtos;

namespace SchoolSystem.Application.Features.Authentication.Commands.Handlers
{
	public class AuthenticationCommandHandler :
		ResponseHandler,
		IRequestHandler<SignInCommand, Response<UserDto>>,
		IRequestHandler<RefreshTokenCommand, Response<UserDto>>,
		IRequestHandler<RevokeRefreshTokenCommand, Response<bool>>
	{
		private readonly IStringLocalizer<SharedResources> _localizer;
		private readonly IAuthenticationService _authenticationService;
		public AuthenticationCommandHandler(IStringLocalizer<SharedResources> localizer, IAuthenticationService authenticationService)
			: base(localizer)
		{
			_localizer = localizer;
			_authenticationService = authenticationService;
		}

		public async Task<Response<UserDto>> Handle(SignInCommand request, CancellationToken cancellationToken)
		{
			var result = await _authenticationService.SignInAsync(request.Email, request.Password);


			if (result.Status == Status.NotFound)
				return NotFound<UserDto>(_localizer[SharedResourcesKeys.EmailNotFound]);

			else if (result.Status == Status.LockedOut)
				return BadRequest<UserDto>(_localizer[SharedResourcesKeys.LockedOut]);

			else if (result.Status == Status.InvalidPassword)
				return BadRequest<UserDto>(_localizer[SharedResourcesKeys.InvalidPassword]);


			else if (result.Status == Status.EmailNotConfirmed)
				return BadRequest<UserDto>(_localizer[SharedResourcesKeys.EmailNotConfirmed]);

			else
				return Success(result, _localizer[SharedResourcesKeys.Success]);
		}

		public async Task<Response<UserDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
		{
			var result = await _authenticationService.GetRefreshToken(new RefreshDto
			{
				Token = request.Token,
				RefreshToken = request.RefreshToken
			});

			if (result.Status == Status.NotFound)
				return NotFound<UserDto>(_localizer[SharedResourcesKeys.NotFound]);

			else if (result.Status == Status.TokenNotFound)
				return BadRequest<UserDto>("Token Not Found");

			else
				return Success(result, _localizer[SharedResourcesKeys.Success]);
		}

		public async Task<Response<bool>> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
		{
			var result = await _authenticationService.RevokeRefreshToken(new RefreshDto
			{
				Token = request.Token,
				RefreshToken = request.RefreshToken
			});

			if (result)
				return Success(true, _localizer[SharedResourcesKeys.Success]);
			else
				return NotFound<bool>(_localizer[SharedResourcesKeys.NotFound]);
		}
	}
}
