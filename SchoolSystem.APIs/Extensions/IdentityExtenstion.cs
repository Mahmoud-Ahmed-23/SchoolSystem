using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SchoolSystem.Data.Entities.Identity;
using SchoolSystem.Infrastructure.DbContexts;
using System.Text;

namespace SchoolSystem.APIs.Extensions
{
	public static class IdentityExtenstion
	{
		public static IServiceCollection AddIdentityServices(this IServiceCollection services,IConfiguration configuration)
		{
			services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			{
				options.Password.RequireDigit = true;
				options.Password.RequiredLength = 6;
				options.Password.RequireLowercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;

				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				options.Lockout.MaxFailedAccessAttempts = 5;
				options.Lockout.AllowedForNewUsers = true;


				options.User.RequireUniqueEmail = true;

				options.SignIn.RequireConfirmedEmail = false;
				options.SignIn.RequireConfirmedAccount = false;
			})
				.AddEntityFrameworkStores<SchoolDbContext>()
				.AddDefaultTokenProviders()
				.AddErrorDescriber<IdentityErrorDescriber>();

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer((configurationOptions) =>
			{
				configurationOptions.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateAudience = true,
					ValidateIssuer = true,
					ValidateIssuerSigningKey = true,
					ValidateLifetime = true,


					ClockSkew = TimeSpan.FromHours(0),
					ValidAudience = configuration["JwtSettings:Audience"],
					ValidIssuer = configuration["JwtSettings:Issuer"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!))
				};
			});


			return services;
		}
	}
}
