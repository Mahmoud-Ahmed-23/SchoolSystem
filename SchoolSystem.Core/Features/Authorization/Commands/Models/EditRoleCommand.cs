using MediatR;
using SchoolSystem.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Authorization.Commands.Models
{
	public class EditRoleCommand : IRequest<Response<string>>
	{
		public string Id { get; set; }
		public string NewRoleName { get; set; }
		public EditRoleCommand(string id, string newRoleName)
		{
			Id = id;
			NewRoleName = newRoleName;
		}
	}
}
