using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolSystem.Application._SharedResources;
using SchoolSystem.Application.Features.Accounts.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Features.Accounts.Commands.Validators
{
	internal class AddUserValidator : AbstractValidator<AddUserCommand>
	{
		private readonly IStringLocalizer<SharedResources> _localizer;

		public AddUserValidator(IStringLocalizer<SharedResources> stringLocalizer)
		{
			_localizer = stringLocalizer;

			ApplyValidationsRules();
		}

		public void ApplyValidationsRules()
		{
			RuleFor(e => e.FullName).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
									.NotNull().WithMessage("Name Must not Be Null")
									.MaximumLength(100).WithMessage("Max Length is 100");

			RuleFor(e => e.Email).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
								 .NotNull().WithMessage("Email Must not Be Null")
								 .MaximumLength(100).WithMessage("Max Length is 100");

			RuleFor(e => e.Password).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
									.NotNull().WithMessage("Password Must not Be Null")
									.MaximumLength(100).WithMessage("Max Length is 100");

		}
	}
}
