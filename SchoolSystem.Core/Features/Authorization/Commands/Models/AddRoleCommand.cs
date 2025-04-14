using MediatR;
using SchoolSystem.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Authorization.Commands.Models
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
