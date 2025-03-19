using FluentValidation;
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


		public AddStudentValidators()
		{
			ApplyValidationRules();
		}

		public void ApplyValidationRules()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.NotNull();
		}
	}
}
