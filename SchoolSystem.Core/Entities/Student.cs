﻿using SchoolSystem.Core.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Core.Entities
{
	public class Student : GeneralLocalizableEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string? NameEn { get; set; }
		public string? NameAr { get; set; }


		[StringLength(500)]
		public string? Address { get; set; }


		[StringLength(500)]
		public string? Phone { get; set; }


		public int? DepartmentId { get; set; }


		[ForeignKey(nameof(DepartmentId))]
		[InverseProperty(nameof(Department.Students))]
		public virtual Department? Department { get; set; }


		[InverseProperty("Student")]
		public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = new HashSet<StudentSubject>();

	}
}