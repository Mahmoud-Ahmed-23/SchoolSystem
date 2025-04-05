using MediatR;
using SchoolSystem.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Accounts.Commands.Models
{
	public class AddUserCommand : IRequest<Response<string>>
	{
		public string FullName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Address { get; set; }

		//public string Role { get; set; }

		public AddUserCommand(string fullName, string password, string email, string? phoneNumber, string? address/*, string role*/)
		{
			FullName = fullName;
			Password = password;
			Email = email;
			PhoneNumber = phoneNumber;
			Address = address;
			//Role = role;
		}
	}
}
