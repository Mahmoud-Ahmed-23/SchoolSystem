using SchoolSystem.Core.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Core.Entities
{
	public class Subject : GeneralLocalizableEntity
	{

		[Key]
		public int Id { get; set; }


		[StringLength(500)]
		public string? NameEn { get; set; }
		public string? NameAr { get; set; }



		public int Period { get; set; }


		[InverseProperty("Subject")]
		public virtual ICollection<StudentSubject> StudentsSubjects { get; set; } = new HashSet<StudentSubject>();


		[InverseProperty("Subject")]
		public virtual ICollection<DepartmentSubject> DepartmetsSubjects { get; set; } = new HashSet<DepartmentSubject>();


		[InverseProperty("Subject")]
		public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; } = new HashSet<InstructorSubject>();

	}
}