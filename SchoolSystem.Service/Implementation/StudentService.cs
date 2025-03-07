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
	}
}
