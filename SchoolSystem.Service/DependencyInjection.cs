using Microsoft.Extensions.DependencyInjection;
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
		public static IServiceCollection AddService_Services(this IServiceCollection services)
		{
			services.AddTransient(typeof(IStudentService), typeof(StudentService));


			return services;
		}
	}
}
