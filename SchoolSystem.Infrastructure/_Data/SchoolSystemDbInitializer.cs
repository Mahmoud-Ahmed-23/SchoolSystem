using Microsoft.EntityFrameworkCore;
using SchoolSystem.Infrastructure._Data.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure._Data
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
