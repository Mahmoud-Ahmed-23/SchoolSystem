﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.APIs.Bases;
using SchoolSystem.Application.Features.Departments.Queries.Models;
using SchoolSystem.Application.Features.Departments.Results;
using SchoolSystem.Core.AppMetaData;

namespace SchoolSystem.APIs.Controllers.Departments
{
	public class DepartmentController : BaseApiController
	{

		[HttpGet(Router.DepartmentRouting.list)]
		public async Task<ActionResult<List<ReturnDepartmentResponse>>> GetDepartmentList()
		{
			var result = await mediator.Send(new GetDepartmentListQuery());
			return NewResult(result);
		}

		[HttpGet(Router.DepartmentRouting.id)]
		public async Task<ActionResult<ReturnDepartmentByIdResponse>> GetDepartmentById([FromRoute] int id)
		{
			var result = await mediator.Send(new GetDepartmentByIdQuery(id));
			return NewResult(result);
		}

	}
}
