using MediatR;
using SchoolSystem.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Features.Authorization.Commands.Models
{
	public class AddRoleCommand : IRequest<Response<string>>
	{
		public string RoleName { get; set; } = string.Empty;
		public AddRoleCommand(string roleName)
		{
			RoleName = roleName;
		}
	}
}
