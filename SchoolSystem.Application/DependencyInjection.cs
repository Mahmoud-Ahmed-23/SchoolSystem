using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolSystem.Application.Features.Students.Behaviors;
using SchoolSystem.Application.Mapping.Departments;
using SchoolSystem.Application.Mapping.Students;
using SchoolSystem.Application.Services.Abstracts.SendEmail;
using SchoolSystem.Application.Services.Abstracts;
using SchoolSystem.Application.Services.Implementation;
using SchoolSystem.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
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


			#region Services Registeration

			services.AddTransient(typeof(IStudentService), typeof(StudentService));

			services.AddTransient(typeof(IDepartmentService), typeof(DepartmentService));

			services.AddTransient(typeof(IAuthService), typeof(AuthService));

			services.AddTransient(typeof(IAuthenticationService), typeof(AuthenticationService));

			services.AddTransient(typeof(IAuthorizationService), typeof(AuthorizationService));

			services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

			services.AddTransient(typeof(IEmailService), typeof(EmailService));

			var JwtSettings = new JwtSettings();

			configuration.GetSection(nameof(JwtSettings)).Bind(JwtSettings);

			services.AddSingleton(JwtSettings);

			#endregion


			return services;
		}
	}
}
