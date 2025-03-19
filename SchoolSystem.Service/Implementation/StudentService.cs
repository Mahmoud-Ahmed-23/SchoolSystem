using SchoolProject.Data.Entities;
using SchoolSystem.Infrastructure.Abstracts;
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

			var existStudent = repo.GetTableNoTracking().Where(s => s.Name == (student.Name)).FirstOrDefault();

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
			var student = _unitOfWork.GetRepository<Student>().GetTableNoTracking().Where(s => s.Name == name && s.Id != id).FirstOrDefault();

			if (student is null)
				return false;
			else return true;
		}
	}
}
