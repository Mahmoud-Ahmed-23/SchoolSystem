using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolSystem.Application._SharedResources;
using SchoolSystem.Application.Bases;
using SchoolSystem.Application.Features.Departments.Queries.Models;
using SchoolSystem.Application.Features.Departments.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Application.Services.Abstracts;

namespace SchoolSystem.Application.Features.Departments.Queries.Handlers
{
	public class DepartmentQueryHandler :
		ResponseHandler,
		IRequestHandler<GetDepartmentListQuery, Response<List<ReturnDepartmentResponse>>>,
		IRequestHandler<GetDepartmentByIdQuery, Response<ReturnDepartmentByIdResponse>>
	{
		private readonly IDepartmentService _departmentService;
		private readonly IStringLocalizer<SharedResources> _localizer;
		private readonly IMapper _mapper;

		public DepartmentQueryHandler(IDepartmentService departmentService, IStringLocalizer<SharedResources> localizer, IMapper mapper)
			: base(localizer)
		{
			_departmentService = departmentService;
			_localizer = localizer;
			_mapper = mapper;
		}
		public async Task<Response<List<ReturnDepartmentResponse>>> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
		{
			var departments = await _departmentService.GetAllDepartments();

			var mappedDepartments = _mapper.Map<List<ReturnDepartmentResponse>>(departments);

			var result = Success(mappedDepartments);

			result.Meta = new
			{
				TotalCount = mappedDepartments.Count
			};

			return result;
		}

		public async Task<Response<ReturnDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
		{
			var department = await _departmentService.GetDepartmentById(request.id);

			if (department == null)
				return NotFound<ReturnDepartmentByIdResponse>(_localizer[SharedResourcesKeys.NotFound]);

			var mappedDepartment = _mapper.Map<ReturnDepartmentByIdResponse>(department);

			var result = Success(mappedDepartment);

			result.Meta = new
			{
				TotalCount = 1
			};

			return result;
		}
	}
}
