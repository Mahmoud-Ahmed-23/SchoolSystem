using MediatR;
using SchoolSystem.Core.Bases;
using SchoolSystem.Core.Features.Departments.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Departments.Queries.Models
{
	public class GetDepartmentListQuery : IRequest<Response<List<ReturnDepartmentResponse>>>
	{
	}
}
