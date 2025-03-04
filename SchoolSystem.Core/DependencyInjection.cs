using Microsoft.Extensions.DependencyInjection;
using SchoolSystem.Core.Mapping.Students;
using System;
using System.Collections.Generic;
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

			services.AddAutoMapper(typeof(StudentProfile));

			return services;
		}
	}
}
