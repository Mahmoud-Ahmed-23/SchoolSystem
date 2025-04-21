using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Application.Services.Abstracts;
using SchoolSystem.Core.Abstracts.Persistence;

namespace SchoolSystem.Application.Services.Implementation
{
	internal class DepartmentService(IUnitOfWork _unitOfWork) : IDepartmentService
	{

		public async Task<List<Department>> GetAllDepartments()
		{
			return await _unitOfWork.DepartmentRepository.GetTableNoTracking().ToListAsync();
		}

		public async Task<Department> GetDepartmentById(int id)
		{
			return await _unitOfWork.DepartmentRepository.GetDepartmentById(id);
		}
		public async Task<string> AddDepartment(Department department)
		{
			var departmentExist = await _unitOfWork.DepartmentRepository.IsNameExist(department);

			if (departmentExist)
				return "Depatment is already Exist";

			await _unitOfWork.DepartmentRepository.AddAsync(department);
			await _unitOfWork.CompleteAsync();

			return "Success";
		}

		public async Task<string> UpdateDepartment(Department department)
		{

			var repo = _unitOfWork.DepartmentRepository;

			var checkDepartment = await repo.IsNameExistExcludeSelf(department);

			if (checkDepartment)
				return "Department is already Exist";

			var getDepartment = await repo.GetByIdAsync(department.Id);

			await repo.UpdateAsync(getDepartment);

			await _unitOfWork.CompleteAsync();

			return "Success";

		}
		public async Task<string> DeleteDepartment(Department department)
		{
			var trans = _unitOfWork.DepartmentRepository.BeginTransaction();
			try
			{
				await _unitOfWork.DepartmentRepository.DeleteAsync(department);
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
	}
}
