using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using SchoolSystem.Core.Features.Students.Behaviors;
using SchoolSystem.Core.Mapping.Departments;
using SchoolSystem.Core.Mapping.Students;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddCoreServices(this IServiceCollection services)
		{
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

			
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

			services.Configure<RequestLocalizationOptions>(options =>
			{
				List<CultureInfo> cultures = new List<CultureInfo>
				{
					new CultureInfo("en-US"),
					new CultureInfo("es-ES"),
					new CultureInfo("ar-EG")
				};
				options.DefaultRequestCulture = new RequestCulture("ar-EG");
				options.SupportedCultures = cultures;
				options.SupportedUICultures = cultures;
			});

			return services;
		}
	}
}
