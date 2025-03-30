using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolSystem.Core._SharedResources;
using SchoolSystem.Core.Bases;
using SchoolSystem.Core.Features.Departments.Queries.Models;
using SchoolSystem.Core.Features.Departments.Results;
using SchoolSystem.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Departments.Queries.Handlers
{
	public class DepartmentQueryHandler :
		ResponseHandler,
		IRequestHandler<GetDepartmentListQuery, Response<List<ReturnDepartmentResponse>>>
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
	}
}
