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
	internal class EditUserValidator : AbstractValidator<EditUserCommand>
	{
		private readonly IStringLocalizer<SharedResources> _localizer;
		public EditUserValidator(IStringLocalizer<SharedResources> localizer)
		{
			ApplyValidationsRules();
			_localizer = localizer;
		}


		public void ApplyValidationsRules()
		{
			RuleFor(e => e.FullName).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
							   .MaximumLength(100).WithMessage("Max Length is 100");

			RuleFor(e => e.Email).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
				   .MaximumLength(100).WithMessage("Max Length is 100");
		}
	}
}
