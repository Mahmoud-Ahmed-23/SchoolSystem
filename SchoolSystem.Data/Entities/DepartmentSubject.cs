using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
	public class DepartmentSubject
	{

		public int DepartmentId { get; set; }


		public int SubjectId { get; set; }


		[ForeignKey(nameof(DepartmentId))]
		[InverseProperty(nameof(Department.DepartmentSubjects))]
		public virtual Department? Department { get; set; }


		[ForeignKey(nameof(SubjectId))]
		[InverseProperty(nameof(Subject.DepartmetsSubjects))]
		public virtual Subject? Subject { get; set; }
	}
}