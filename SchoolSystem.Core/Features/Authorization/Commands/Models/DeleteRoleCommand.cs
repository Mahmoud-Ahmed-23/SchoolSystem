using MediatR;
using SchoolSystem.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Authorization.Commands.Models
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
