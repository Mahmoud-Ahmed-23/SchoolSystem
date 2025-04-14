using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace SchoolSystem.Core._SharedResources
{
	public static class SharedResourcesKeys
	{
		public const string Deleted = "Deleted";
		public const string Created = "Created";
		public const string Success = "Success";
		public const string Unauthorized = "Unauthorized";
		public const string BadRequest = "BadRequest";
		public const string NotFound = "NotFound";
		public const string Required = "Required";
		public const string NotEmpty = "NotEmpty";
		public const string Updated = "Updated";
		public const string EmailAlreadyExist = "EmailAlreadyExist";
		public const string PhoneAlreadyExist = "PhoneAlreadyExist";
		public const string LockedOut = "LockedOut";
		public const string InvalidPassword = "InvalidPassword";
		public const string EmailNotConfirmed = "EmailNotConfirmed";
		public const string EmailNotFound = "EmailNotFound";
		public const string RoleAlreadyExist = "RoleAlreadyExist";
		public const string EmailSent = "EmailSent";
		public const string EmailNotSent = "EmailNotSent";
		public const string InvalidResetCode = "InvalidResetCode";
		public const string ResetCodeExpired = "ResetCodeExpired"; 
		public const string EmailConfirmed = "EmailConfirmed"; 

	}
}
