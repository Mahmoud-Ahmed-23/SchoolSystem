using Microsoft.AspNetCore.Identity;

namespace SchoolSystem.Core.Entities.Identity
{
	public class ApplicationUser : IdentityUser
	{
		public required string FullName { get; set; }

		public string? Address { get; set; }

		public int? EmailConfirmResetCode { get; set; }
		public DateTime? EmailConfirmResetCodeExpiry { get; set; }

		public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

	}
}
