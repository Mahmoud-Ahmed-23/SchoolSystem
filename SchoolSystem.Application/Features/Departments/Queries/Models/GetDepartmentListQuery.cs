using MediatR;
using SchoolSystem.Application.Bases;
using SchoolSystem.Application.Features.Departments.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Features.Departments.Queries.Models
{
	public class GetDepartmentListQuery : IRequest<Response<List<ReturnDepartmentResponse>>>
	{
	}
}
