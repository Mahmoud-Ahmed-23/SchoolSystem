using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolSystem.Core._SharedResources;
using SchoolSystem.Core.Features.Accounts.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Accounts.Commands.Validators
{
	public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
	{
		IStringLocalizer<SharedResources> _localizer;
		public ChangePasswordValidator(IStringLocalizer<SharedResources> localizer)
		{
			_localizer = localizer;
		}
		public void ApplyValidationsRules()
		{
			RuleFor(e => e.Id).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
										.NotNull().WithMessage("User Id Must not Be Null")
										.MaximumLength(100).WithMessage("Max Length is 100");

			RuleFor(e => e.NewPassword).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
											.NotNull().WithMessage("New Password Must not Be Null")
											.MaximumLength(100).WithMessage("Max Length is 100");

		}
	}
}
