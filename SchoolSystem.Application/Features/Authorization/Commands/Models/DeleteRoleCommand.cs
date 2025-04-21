using MediatR;
using SchoolSystem.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Features.Authorization.Commands.Models
{
	public class DeleteRoleCommand : IRequest<Response<string>>
	{
		public string roleName { get; set; }
		public DeleteRoleCommand(string rolename)
		{
			roleName = rolename;
		}
	}
}
