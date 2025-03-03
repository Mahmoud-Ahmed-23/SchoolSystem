using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure._Data.Configurations
{
	internal class InstructorSubjectConfiguration : IEntityTypeConfiguration<InstructorSubject>
	{
		public void Configure(EntityTypeBuilder<InstructorSubject> builder)
		{
			builder.HasOne(i => i.instructor)
				.WithMany()
				.HasForeignKey(i => i.InstructorId);

			builder.HasOne(i => i.Subject)
				.WithMany()
				.HasForeignKey(i => i.SubjectId);


			builder.HasKey(x => new { x.SubjectId, x.InstructorId });


		}
	}
}
