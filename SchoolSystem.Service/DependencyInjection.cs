
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolSystem.Data.Helpers;
using SchoolSystem.Service.Abstracts;
using SchoolSystem.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Service
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddTransient(typeof(IStudentService), typeof(StudentService));

			services.AddTransient(typeof(IDepartmentService), typeof(DepartmentService));

			services.AddTransient(typeof(IAuthService), typeof(AuthService));

			services.AddTransient(typeof(IAuthenticationService), typeof(AuthenticationService));

			var JwtSettings = new JwtSettings();

			configuration.GetSection(nameof(JwtSettings)).Bind(JwtSettings);

			services.AddSingleton(JwtSettings);

			return services;
		}
	}
}
