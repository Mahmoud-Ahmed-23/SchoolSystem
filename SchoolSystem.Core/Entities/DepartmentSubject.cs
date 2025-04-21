using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Core.Entities
{
	public class DepartmentSubject
	{
		[Key]
		public int Id { get; set; }
		public int DepartmentId { get; set; }
		public int SubjectId { get; set; }

		public virtual Department? Department { get; set; }

		public virtual Subject? Subject { get; set; }
	}
}