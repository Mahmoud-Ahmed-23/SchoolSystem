using Microsoft.EntityFrameworkCore;
using SchoolSystem.Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.DbContexts
{
	public class SchoolSystemDbInitializer(SchoolDbContext dbContext) : ISchoolSystemDbInitializer
	{
		public async Task InitializeAsync()
		{
			var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();

			if (pendingMigrations.Any())
				await dbContext.Database.MigrateAsync();

		}

	}
}
