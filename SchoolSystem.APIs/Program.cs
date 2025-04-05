
using Microsoft.Extensions.Options;
using SchoolSystem.APIs.Extensions;
using SchoolSystem.Core;
using SchoolSystem.Core.Middlewares;
using SchoolSystem.Infrastructure;
using SchoolSystem.Service;
using SchoolSystem.APIs.Extensions;

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
							.AddCoreServices()
							.AddIdentityServices(builder.Configuration);


			builder.Services.AddControllersWithViews();
			builder.Services.AddLocalization(options => options.ResourcesPath = "");


			var app = builder.Build();

			app.UseMiddleware<ErrorHandlerMiddleware>();
			await app.InitializerSchoolSystemDbContextAsync();
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			var options = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();

			app.UseRequestLocalization(options.Value);

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.UseStaticFiles();

			app.MapControllers();

			app.Run();
		}
	}
}
