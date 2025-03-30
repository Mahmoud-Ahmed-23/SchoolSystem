using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
	public class StudentSubject
	{

		public int StudentId { get; set; }


		public int SubjectId { get; set; }


		public decimal? grade { get; set; }



		[ForeignKey(nameof(StudentId))]
		[InverseProperty(nameof(Student.StudentSubjects))]
		public virtual Student? Student { get; set; }



		[ForeignKey(nameof(SubjectId))]
		[InverseProperty(nameof(Subject.StudentsSubjects))]
		public virtual Subject? Subject { get; set; }

	}
}