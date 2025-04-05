using MediatR;
using SchoolSystem.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Accounts.Commands.Models
{
	public class EditUserCommand : IRequest<Response<string>>
	{
		public required string Id { get; set; }

		public required string FullName { get; set; }

		public required string PhoneNumber { get; set; }

		public required string Email { get; set; }

		public string? Address { get; set; }

		public EditUserCommand(string fullName, string phoneNumber, string email, string? address)
		{
			FullName = fullName;
			PhoneNumber = phoneNumber;
			Email = email;
			Address = address;
		}
	}
}
