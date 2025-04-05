using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolSystem.Core._SharedResources;
using SchoolSystem.Core.Bases;
using SchoolSystem.Core.Features.Accounts.Commands.Models;
using SchoolSystem.Data.Entities.Identity;
using SchoolSystem.Service._Common;
using SchoolSystem.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Accounts.Commands.Handlers
{
	public class UserCommandHandler :
		ResponseHandler,
		IRequestHandler<AddUserCommand, Response<string>>,
		IRequestHandler<EditUserCommand, Response<string>>,
		IRequestHandler<DeleteUserCommand, Response<string>>,
		IRequestHandler<ChangePasswordCommand, Response<string>>

	{
		private readonly IAuthService _authService;
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharedResources> _localizer;
		private readonly UserManager<ApplicationUser> _userManager;


		public UserCommandHandler(IAuthService authService, IMapper mapper, IStringLocalizer<SharedResources> localizer, UserManager<ApplicationUser> userManager)
			: base(localizer)
		{
			_authService = authService;
			_mapper = mapper;
			_localizer = localizer;
			_userManager = userManager;
		}



		public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
		{
			var user = _mapper.Map<ApplicationUser>(request);
			var result = await _authService.AddUserAsync(user, request.Password);
			if (result == Status.Success)
				return Created(result, _localizer[SharedResourcesKeys.Success]);

			return BadRequest<string>(_localizer[SharedResourcesKeys.BadRequest]);
		}



		public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByIdAsync(request.Id);

			if (user is null)
				return NotFound<string>(_localizer[SharedResourcesKeys.NotFound]);

			var findanotheruserwithsameemail = _authService.IsEmailExistExcludeSelf(request.Email, request.Id);

			if (findanotheruserwithsameemail)
				return UnprocessableEntity<string>(_localizer[SharedResourcesKeys.EmailAlreadyExist]);

			var findanotheruserwithsamephone = _authService.IsPhoneExistExcludeSelf(request.PhoneNumber, request.Id);

			if (findanotheruserwithsamephone)
				return UnprocessableEntity<string>(_localizer[SharedResourcesKeys.PhoneAlreadyExist]);


			var mappedUser = _mapper.Map(request, user);

			var result = await _userManager.UpdateAsync(mappedUser);

			if (result.Succeeded)
				return Success<string>(_localizer[SharedResourcesKeys.Success]);

			return BadRequest<string>(_localizer[SharedResourcesKeys.BadRequest]);
		}

		public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
		{
			var result = await _authService.DeleteUserAsync(request.Id);

			if (result == Status.Success)
				return Success(result, _localizer[SharedResourcesKeys.Success]);

			else if (result == Status.NotFound)
				return NotFound<string>(_localizer[SharedResourcesKeys.NotFound]);

			else
				return BadRequest<string>(_localizer[SharedResourcesKeys.BadRequest]);
		}

		public async Task<Response<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
		{
			var result = await _authService.ChangePasswordAsync(request.Id, request.OldPassword, request.NewPassword);

			if (result == Status.Success)
				return Success(result, _localizer[SharedResourcesKeys.Success]);

			else if (result == Status.NotFound)
				return NotFound<string>(_localizer[SharedResourcesKeys.NotFound]);

			else
				return BadRequest<string>(_localizer[SharedResourcesKeys.BadRequest]);
		}
	}
}
