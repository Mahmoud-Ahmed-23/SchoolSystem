using MediatR;
using Microsoft.Extensions.Localization;
using SchoolSystem.Core._SharedResources;
using SchoolSystem.Core.Bases;
using SchoolSystem.Core.Features.Authorization.Queries.Models;
using SchoolSystem.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Authorization.Queries.Handlers
{
	internal class AuthorizationQueryHandler :
		ResponseHandler,
		IRequestHandler<GetRolesListQuery, Response<List<string>>>
	{
		private readonly IStringLocalizer<SharedResources> _localizer;
		private readonly IAuthorizationService _authorizationService;


		public AuthorizationQueryHandler(IStringLocalizer<SharedResources> localizer, IAuthorizationService authorizationService)
			: base(localizer)
		{
			_localizer = localizer;
			_authorizationService = authorizationService;
		}
		public async Task<Response<List<string>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
		{
			var result = await _authorizationService.GetAllRolesAsync();

			if (result.Count == 0)
				return NotFound<List<string>>(_localizer[SharedResourcesKeys.NotFound]);

			return Success(result, _localizer[SharedResourcesKeys.Success]);
		}
	}
}
