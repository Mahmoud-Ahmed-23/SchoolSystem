using MediatR;
using SchoolSystem.Application.Bases;
using SchoolSystem.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Features.Authentication.Commands.Models
{
	public class RefreshTokenCommand : IRequest<Response<UserDto>>
	{
		public string RefreshToken { get; set; }
		public string Token { get; set; }

	}
}
