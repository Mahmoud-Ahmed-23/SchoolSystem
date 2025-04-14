using MediatR;
using SchoolSystem.Core.Bases;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Emails.Commands.Models
{
	public class SendCodeCommand : IRequest<Response<string>>
	{
		public string Email { get; set; }
	}
}
