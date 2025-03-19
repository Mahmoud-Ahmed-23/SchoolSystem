
using SchoolSystem.APIs.Extensions;
using SchoolSystem.Core;
using SchoolSystem.Core.Middlewares;
using SchoolSystem.Infrastructure;
using SchoolSystem.Service;

namespace SchoolSystem.APIs
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddInfrastructureServices(builder.Configuration)
							.AddService_Services()
							.AddCoreServices();


			var app = builder.Build();

			app.UseMiddleware<ErrorHandlerMiddleware>();
			await app.InitializerSchoolSystemDbContextAsync();
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
