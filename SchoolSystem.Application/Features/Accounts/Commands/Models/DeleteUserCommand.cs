using MediatR;
using SchoolSystem.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Features.Accounts.Commands.Models
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
