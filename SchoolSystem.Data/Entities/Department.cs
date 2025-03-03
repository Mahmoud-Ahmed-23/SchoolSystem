using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
	public class Department 
	{
		[Key]

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }


		[StringLength(200)]
		public string? Name { get; set; }


		public int? InsManger { get; set; }
		
		
		[InverseProperty("Department")]
		public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();


		[InverseProperty("Department")]
		public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; } = new HashSet<DepartmentSubject>();

		
		[InverseProperty("department")]
		public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();

		
		[ForeignKey("InsManger")]
		[InverseProperty("departmentManager")]
		public virtual Instructor? Instructor { get; set; }

	}
}