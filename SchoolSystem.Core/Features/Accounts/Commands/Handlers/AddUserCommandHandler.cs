using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolSystem.Core._SharedResources;
using SchoolSystem.Core.Bases;
using SchoolSystem.Core.Features.Accounts.Commands.Models;
using SchoolSystem.Data.Entities.Identity;
using SchoolSystem.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Accounts.Commands.Handlers
{
	public class AddUserCommandHandler :
		ResponseHandler,
		IRequestHandler<AddUserCommand, Response<string>>
	{
		private readonly IAuthService _authService;
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharedResources> _localizer;

		public AddUserCommandHandler(IAuthService authService, IMapper mapper, IStringLocalizer<SharedResources> localizer)
			: base(localizer)
		{
			_authService = authService;
			_mapper = mapper;
			_localizer = localizer;
		}



		public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
		{
			var user = _mapper.Map<ApplicationUser>(request);
			var result = await _authService.AddUserAsync(user, request.Password);
			if (result == "Success")
				return Created(result, _localizer[SharedResourcesKeys.Success]);

			return BadRequest<string>();
		}
	}
}
