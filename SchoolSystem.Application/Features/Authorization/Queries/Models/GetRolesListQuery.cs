using MediatR;
using SchoolSystem.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Features.Authorization.Queries.Models
{
	public class GetRolesListQuery : IRequest<Response<List<string>>>
	{
	}
}
