using MediatR;
using SchoolSystem.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Features.Authentication.Commands.Models
{
	public class RevokeRefreshTokenCommand : IRequest<Response<bool>>
	{
		public string Token { get; set; }
		public string RefreshToken { get; set; }
	}
}
