using MediatR;
using SchoolSystem.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Features.Accounts.Commands.Models
{
	public class ChangePasswordCommand:IRequest<Response<string>>
	{
		public string Id { get; set; }
		public string OldPassword { get; set; }
		public string NewPassword { get; set; }
		public ChangePasswordCommand(string id, string oldPassword, string newPassword)
		{
			Id = id;
			OldPassword = oldPassword;
			NewPassword = newPassword;
		}
	}
}
