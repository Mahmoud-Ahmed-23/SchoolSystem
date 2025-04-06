using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Service._Common
{
	public static class Status
	{
		public static string BadRequest = "BadRequest";
		public static string NotFound = "NotFound";
		public static string Success = "Success";
		public static string Unauthorized = "Unauthorized";
		public static string Exist = "Exist";
		public static string InvalidPassword = "InvalidPassword";
		public static string LockedOut = "LockedOut";
		public static string NotAllowed = "NotAllowed";
		public static string EmailNotConfirmed = "EmailNotConfirmed";
	}
}
