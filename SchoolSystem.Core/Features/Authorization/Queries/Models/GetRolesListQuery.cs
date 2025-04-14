using MediatR;
using SchoolSystem.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Authorization.Queries.Models
{
	public class GetRolesListQuery : IRequest<Response<List<string>>>
	{
	}
}
