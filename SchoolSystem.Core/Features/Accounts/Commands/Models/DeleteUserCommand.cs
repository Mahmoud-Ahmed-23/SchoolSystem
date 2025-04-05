using MediatR;
using SchoolSystem.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Accounts.Commands.Models
{
	public class DeleteUserCommand : IRequest<Response<string>>
	{
		public string Id { get; set; }

		public DeleteUserCommand(string id)
		{
			Id = id;
		}
	}
}
