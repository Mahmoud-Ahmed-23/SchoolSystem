
using MailKit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolSystem.Core.Helpers;
using SchoolSystem.Application.Services.Abstracts;
using SchoolSystem.Application.Services.Abstracts.SendEmail;
using SchoolSystem.Application.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
		{
			

			return services;
		}
	}
}
