using Microsoft.AspNetCore.Identity;

namespace SchoolSystem.Data.Entities.Identity
{
	public class ApplicationUser : IdentityUser
	{
		public required string FullName { get; set; }

		public string? Address { get; set; }

	}
}
