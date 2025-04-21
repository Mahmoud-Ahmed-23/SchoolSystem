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
	public class SignInCommand : IRequest<Response<UserDto>>
	{
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public SignInCommand(string email, string password)
		{
			Email = email;
			Password = password;
		}
	}
}
