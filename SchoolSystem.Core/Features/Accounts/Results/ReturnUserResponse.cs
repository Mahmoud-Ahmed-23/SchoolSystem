using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Accounts.Results
{
	public class ReturnUserResponse
	{

		public required string Id { get; set; }

		public required string FullName { get; set; }

		public required string Password { get; set; }

		public required string PhoneNumber { get; set; }

		public required string Email { get; set; }

		public string? Address { get; set; }
	}
}
