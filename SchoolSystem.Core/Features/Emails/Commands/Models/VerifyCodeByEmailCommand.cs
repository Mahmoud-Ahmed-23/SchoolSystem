using MediatR;
using SchoolSystem.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Emails.Commands.Models
{
	public class VerifyCodeByEmailCommand : IRequest<Response<string>>
	{
		public required string Email { get; set; }
		public required int resetCode { get; set; }
	}
}
