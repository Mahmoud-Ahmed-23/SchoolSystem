using MediatR;
using SchoolSystem.Core.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Emails.Commands.Models
{
	public class ConfirmEmailCommand : IRequest<Response<string>>
	{
		public required string Email { get; set; }

		public int ConfirmationCode { get; set; }
	}
}
