using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.Configurations
{
	public class StudentConfigurations : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.NameEn)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(e => e.Address)
				.IsRequired()
				.HasMaxLength(100);

		}
	}
}
