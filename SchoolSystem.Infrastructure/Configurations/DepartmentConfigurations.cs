using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.Configurations
{
	internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
	{
		public void Configure(EntityTypeBuilder<Department> builder)
		{
			builder.Property(e => e.NameEn)
				.HasMaxLength(200);

			builder.Property(e => e.NameAr)
				.HasMaxLength(200);

			builder.HasMany(e => e.Students)
				.WithOne(e => e.Department)
				.HasForeignKey(e => e.DepartmentId);

			//builder.HasMany(e => e.DepartmentSubjects)
			//	.WithOne(e => e.Department)
			//	.HasForeignKey(e => e.DepartmentId);

			builder.HasMany(e => e.Instructors)
				.WithOne(e => e.department)
				.HasForeignKey(e => e.DepartmentId);

			builder.HasOne(e => e.Manager)
				.WithOne(e => e.departmentManager)
				.HasForeignKey<Department>(x => x.InsManger);
		}
	}
}
