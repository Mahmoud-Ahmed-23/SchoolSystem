using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolSystem.Application._SharedResources;
using SchoolSystem.Application.Bases;
using SchoolSystem.Application.Features.Accounts.Queries.Models;
using SchoolSystem.Application.Features.Accounts.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Application.Services.Abstracts;

namespace SchoolSystem.Application.Features.Accounts.Queries.Handlers
{
	internal class UserQueryHandler :
			ResponseHandler,
			IRequestHandler<GetUserByIdQuery, Response<ReturnUserResponse>>
	{
		private readonly IStringLocalizer<SharedResources> _localizer;
		private readonly IAuthService _authService;
		private readonly IMapper _mapper;

		public UserQueryHandler(IStringLocalizer<SharedResources> localizer, IAuthService authService, IMapper mapper)
		: base(localizer)
		{
			_localizer = localizer;
			_authService = authService;
			_mapper = mapper;
		}

		public async Task<Response<ReturnUserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
		{
			var user = await _authService.GetUserByIdAsync(request.Id);

			if (user == null)
			{
				return NotFound<ReturnUserResponse>(_localizer["UserNotFound"]);
			}

			var mappedUser = _mapper.Map<ReturnUserResponse>(user);

			var result = Success(mappedUser);

			result.Meta = new
			{
				TotalCount = 1
			};

			return result;

		}
	}
}
