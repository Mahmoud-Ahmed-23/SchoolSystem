using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Core.Entities
{
	public class InstructorSubject
	{
		[Key]
		public int InstructorId { get; set; }
		[Key]
		public int SubjectId { get; set; }
		public Instructor? instructor { get; set; }
		public Subject? Subject { get; set; }
	}
}