using MediatR;
using SchoolSystem.Core.Bases;
using SchoolSystem.Core.Features.Accounts.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Accounts.Queries.Models
{
	public class GetUserByIdQuery : IRequest<Response<ReturnUserResponse>>
	{
		public string Id { get; set; }

		public GetUserByIdQuery(string Id)
		{
			this.Id = Id;
		}
	}
}
