using SchoolProject.Data.Entities;
using SchoolSystem.Infrastructure.Abstracts;
using SchoolSystem.Infrastructure.Specifications._SpecParams;
using SchoolSystem.Infrastructure.Specifications._SpecParams.Students;
using SchoolSystem.Infrastructure.Specifications.Students;
using SchoolSystem.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Service.Implementation
{
	internal class StudentService(IUnitOfWork _unitOfWork) : IStudentService
	{
		public async Task<List<Student>> GetStudentsList()
		{
			var students = await _unitOfWork.StudentRepository.GetAllStudents();
			return students;
		}

		public async Task<Student> GetStudentById(int id)
		{
			var student = await _unitOfWork.GetRepository<Student>().GetByIdAsync(id);

			return student;
		}

		public async Task<string> AddStudent(Student student)
		{
			var repo = _unitOfWork.GetRepository<Student>();

			var existStudent = repo.GetTableNoTracking().Where(s => s.NameEn == (student.NameEn)).FirstOrDefault();

			if (existStudent is not null)
				return "Fail";

			await repo.AddAsync(student);

			var complete = await _unitOfWork.CompleteAsync() > 0;

			if (complete)
				return "Success";

			return "Fail";

		}

		public async Task<string> UpdateStudent(Student student)
		{
			await _unitOfWork.StudentRepository.UpdateAsync(student);
			await _unitOfWork.CompleteAsync();
			return "Success";
		}

		public async Task<string> DeleteStudent(Student student)
		{
			var trans = _unitOfWork.StudentRepository.BeginTransaction();
			try
			{
				await _unitOfWork.StudentRepository.DeleteAsync(student);
				await _unitOfWork.CompleteAsync();
				await trans.CommitAsync();
				return "Success";
			}
			catch
			{
				await trans.RollbackAsync();
				return "Fail";
			}
		}

		public async Task<bool> GetNameIfExistExcludeItSelf(string name, int id)
		{
			var student = _unitOfWork.GetRepository<Student>().GetTableNoTracking().Where(s => s.NameEn == name && s.Id != id).FirstOrDefault();

			if (student is null)
				return false;
			else return true;
		}

		public async Task<Pagination<Student>> GetPaginatedStudentsList(StudentSpecParams specParams)
		{
			var spec = new StudentWithDepartmentSpecifications(specParams.Sort, specParams.DepartmentId, specParams.PageIndex, specParams.PageSize, specParams.Search);

			var countSpec = new StudentSpecForCountSpecifications(specParams.DepartmentId, specParams.Search);

			var count = await _unitOfWork.GetRepository<Student>().GetCountAsync(countSpec);

			var students = await _unitOfWork.GetRepository<Student>().GetAllWithSpecAsync(spec);

			return new Pagination<Student>(specParams.PageIndex, specParams.PageSize, count) { Data = students };
		}
	}
}
