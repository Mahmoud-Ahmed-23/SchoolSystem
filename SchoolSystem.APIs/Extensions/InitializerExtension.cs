using SchoolSystem.Infrastructure._Data.Abstracts;

namespace SchoolSystem.APIs.Extensions
{
	public static class InitializerExtension
	{
		public async static Task<WebApplication> InitializerSchoolSystemDbContextAsync(this WebApplication webApplication)
		{
			using var scope = webApplication.Services.CreateScope();

			var services = scope.ServiceProvider;

			var schoolContext = services.GetRequiredService<ISchoolSystemDbInitializer>();

			try
			{
				await schoolContext.InitializeAsync();
			}
			catch (Exception ex)
			{

				throw;
			}

			return webApplication;
		}

	}
}
