﻿using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Entities;
using SchoolSystem.Core.Abstracts.Persistence.Departments;
using SchoolSystem.Infrastructure.Persistence.DbContexts;
using SchoolSystem.Infrastructure.Persistence.InfastructureBases.GenericRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.Repositories
{
	internal class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
	{
		private readonly SchoolDbContext _dbContext;

		public DepartmentRepository(SchoolDbContext dbContext)
			: base(dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<Department> GetDepartmentById(int id)
		{
			return await _dbContext.Departments
									.Where(d => d.Id == id)
									.Include(d => d.Manager)
									.Include(d => d.DepartmentSubjects).ThenInclude(ds => ds.Subject)
									.Include(d => d.Instructors)
									.Include(d => d.Students).FirstOrDefaultAsync();
		}
		public async Task<List<Department>> GetAllDepartments()
			=> await _dbContext.Departments.Include(d => d.Manager).ToListAsync();

		public async Task<bool> IsNameExist(Department department)
		{
			var ExistDepartment = await _dbContext.Departments
				.AnyAsync(d => d.NameEn == department.NameEn || d.NameAr == department.NameAr);

			return ExistDepartment;
		}

		public async Task<bool> IsNameExistExcludeSelf(Department department)
		{
			var ExistDepartment = await _dbContext.Departments
				.AnyAsync(d => d.NameEn == department.NameEn || d.NameAr == department.NameAr && d.Id != department.Id);

			return ExistDepartment;
		}

	}
}
