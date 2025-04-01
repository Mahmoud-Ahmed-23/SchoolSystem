using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
	public class StudentSubject
	{

		[Key]
		public int Id { get; set; }
		public int StudentId { get; set; }
		public int SubjectId { get; set; }

		public decimal? grade { get; set; }

		public virtual Student? Student { get; set; }

		public virtual Subject? Subject { get; set; }

	}
}