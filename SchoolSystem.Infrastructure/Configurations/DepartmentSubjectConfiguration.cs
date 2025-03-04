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
	internal class DepartmentSubjectConfiguration : IEntityTypeConfiguration<DepartmentSubject>
	{
		public void Configure(EntityTypeBuilder<DepartmentSubject> builder)
		{
			builder.HasOne(ds => ds.Subject)
				.WithMany()
				.HasForeignKey(ds => ds.SubjectId);

			builder.HasOne(ds => ds.Department)
				.WithMany()
				.HasForeignKey(ds => ds.DepartmentId);

			builder.HasKey(x => new { x.SubjectId, x.DepartmentId });


		}
	}
}
