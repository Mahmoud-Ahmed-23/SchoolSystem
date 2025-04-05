using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolSystem.Core._SharedResources;
using SchoolSystem.Core.Features.Students.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Students.Commands.Validators
{
	public class AddStudentValidators : AbstractValidator<AddStudentCommand>
	{
		private readonly IStringLocalizer<SharedResources> _localizer;

		public AddStudentValidators(IStringLocalizer<SharedResources> localizer)
		{
			_localizer = localizer;
			ApplyValidationRules();
		}

		public void ApplyValidationRules()
		{
			RuleFor(e => e.Name).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
							   .NotNull().WithMessage("Name Must not Be Null")
							   .MaximumLength(100).WithMessage("Max Length is 10");

			RuleFor(e => e.Address).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
							  .NotNull().WithMessage("{PropertyValue} Must not Be Null")
							  .MaximumLength(100).WithMessage("{PropertyName} Length is 10");

			RuleFor(e => e.DepartmentId).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
										.NotNull().WithMessage("Department Must Not Null , Must Be Requerd");
		}
	}
}
