﻿using SchoolSystem.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
	public class Instructor : GeneralLocalizableEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int InstructorId { get; set; }


		public string? NameEn { get; set; }
		public string? NameAr { get; set; }


		public string? Address { get; set; }


		public string? Position { get; set; }


		public int? SupervisorId { get; set; }


		public decimal? Salary { get; set; }


		public string? Image { get; set; }


		public int? DepartmentId { get; set; }


		[ForeignKey(nameof(DepartmentId))]
		[InverseProperty("Instructors")]
		public Department? department { get; set; }



		[InverseProperty("Manager")]
		public Department? departmentManager { get; set; }


		[ForeignKey(nameof(SupervisorId))]
		[InverseProperty("Instructors")]
		public Instructor? Supervisor { get; set; }


		[InverseProperty("Supervisor")]
		public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();


		[InverseProperty("instructor")]
		public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; } = new HashSet<InstructorSubject>();

		

	}
}