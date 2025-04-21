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
	public class InstructorConfigurations : IEntityTypeConfiguration<Instructor>
	{
		public void Configure(EntityTypeBuilder<Instructor> builder)
		{

			builder.HasOne(i => i.Supervisor)
				.WithMany()
				.HasForeignKey(i => i.SupervisorId);

			builder.HasKey(i => i.InstructorId);
		}
	}
}
