using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolSystem.Core.Abstracts.Persistence;
using SchoolSystem.Core.Abstracts.Persistence.DbInitializer;
using SchoolSystem.Core.Abstracts.Persistence.Departments;
using SchoolSystem.Core.Abstracts.Persistence.Students;
using SchoolSystem.Infrastructure.Persistence.DbContexts;
using SchoolSystem.Infrastructure.Persistence.InfastructureBases.GenericRepos;
using SchoolSystem.Infrastructure.Persistence.UnitOfwork;
using SchoolSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<SchoolDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("SchooldbContext")));

			services.AddTransient(typeof(ISchoolSystemDbInitializer), typeof(SchoolSystemDbInitializer));
			services.AddTransient(typeof(IStudentRepository), typeof(StudentRepository));
			services.AddTransient(typeof(IDepartmentRepository), typeof(DepartmentRepository));
			services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));


			return services;
		}
	}
}
