using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
	public class InstructorSubject
	{
		public int InstructorId { get; set; }


		public int SubjectId { get; set; }


		[ForeignKey(nameof(InstructorId))]
		[InverseProperty(nameof(Instructor.InstructorSubjects))]
		public Instructor? instructor { get; set; }


		[ForeignKey(nameof(SubjectId))]
		[InverseProperty(nameof(Subject.InstructorSubjects))]
		public Subject? Subject { get; set; }
	}
}