using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.Persistence.Configurations
{
	public class InstructorSubjectConfiguration : IEntityTypeConfiguration<InstructorSubject>
	{
		public void Configure(EntityTypeBuilder<InstructorSubject> builder)
		{
			builder.HasOne(i => i.instructor)
				.WithMany(i => i.InstructorSubjects)
				.HasForeignKey(i => i.InstructorId);

			builder.HasOne(i => i.Subject)
				.WithMany(i => i.InstructorSubjects)
				.HasForeignKey(i => i.SubjectId);


			builder.HasKey(x => new { x.SubjectId, x.InstructorId });


		}
	}
}
