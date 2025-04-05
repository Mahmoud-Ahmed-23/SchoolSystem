﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolSystem.Data.Entities.Identity;
namespace SchoolSystem.Infrastructure.DbContexts
{
	public class SchoolDbContext : IdentityDbContext<ApplicationUser>
	{
		public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
			: base(options)
		{

		}
	
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyInformation).Assembly);
		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
		public DbSet<StudentSubject> StudentSubjects { get; set; }



	}
}
