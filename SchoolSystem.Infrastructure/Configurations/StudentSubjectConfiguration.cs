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
	internal class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
	{
		public void Configure(EntityTypeBuilder<StudentSubject> builder)
		{
			builder.HasOne(ss => ss.Student)
				.WithMany()
				.HasForeignKey(ss => ss.StudentId);

			builder.HasOne(ss => ss.Subject)
				.WithMany()
				.HasForeignKey(ss => ss.SubjectId);

			builder.HasKey(x => new { x.StudentId, x.SubjectId });


		}
	}
}
