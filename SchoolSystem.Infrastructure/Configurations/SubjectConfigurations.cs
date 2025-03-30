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
	public class SubjectConfigurations : IEntityTypeConfiguration<Subject>
	{
		public void Configure(EntityTypeBuilder<Subject> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.NameEn)
				.HasMaxLength(500);

			//builder.HasMany(x => x.StudentsSubjects)
			//	.WithOne(x => x.Subject)
			//	.HasForeignKey(x => x.SubjectId);

			//builder.HasMany(x => x.InstructorSubjects)
			//	.WithOne(x => x.Subject)
			//	.HasForeignKey(x => x.SubjectId);

		}
	}
}
