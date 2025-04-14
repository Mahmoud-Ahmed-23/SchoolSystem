using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolSystem.Core._SharedResources;
using SchoolSystem.Core.Features.Authorization.Commands.Models;
using SchoolSystem.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Authorization.Commands.Validators
{
	public class AddRoleValidator : AbstractValidator<AddRoleCommand>
	{
		private readonly IStringLocalizer<SharedResources> _localizer;
		private readonly IAuthorizationService _authorizationService;

		public AddRoleValidator(IStringLocalizer<SharedResources> localizer, IAuthorizationService authorizationService)
		{
			_localizer = localizer;
			_authorizationService = authorizationService;
			ApplyValidationsRules();
			ApplyCustomValidationsRules();
		}

		public void ApplyValidationsRules()
		{
			RuleFor(e => e.RoleName).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
							   .NotNull().WithMessage("Name Must not Be Null")
							   .MaximumLength(100).WithMessage("Max Length is 10");
		}
		public void ApplyCustomValidationsRules()
		{
			RuleFor(x => x.RoleName)
				.MustAsync(async (key, CancellationToken) => !await _authorizationService.RoleIsExist(key))
				.WithMessage("Role is Exist");

		}

	}
}
