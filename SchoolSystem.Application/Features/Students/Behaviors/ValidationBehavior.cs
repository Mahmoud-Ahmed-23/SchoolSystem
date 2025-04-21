using FluentValidation;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolSystem.Application._SharedResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Features.Students.Behaviors
{
	public class ValidationBehavior<TRequest, TResponse>(
		IEnumerable<IValidator<TRequest>> _validators,
		IStringLocalizer<SharedResources> _localizer) : IPipelineBehavior<TRequest, TResponse>
	{
		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			if (_validators.Any())
			{
				var context = new ValidationContext<TRequest>(request);
				var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
				var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

				if (failures.Count != 0)
				{
					var message = failures.Select(X => _localizer[$"{X.PropertyName}"] + ": " + _localizer[X.ErrorMessage]).FirstOrDefault();

					throw new ValidationException(message);

				}
			}
			return await next();
		}
	}
}
