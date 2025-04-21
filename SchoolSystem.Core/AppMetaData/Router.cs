using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.AppMetaData
{
	public class Router
	{
		public const string root = "api";
		public const string version = "v1";
		public const string Rule = root + "/" + version + "/";

		public static class StudentRouting
		{
			public const string prefix = Rule + "student";
			public const string list = prefix + "/list";
			public const string PaginatedList = prefix + "/PaginatedList";
			public const string id = prefix + "/{id}";
			public const string add = prefix + "/add";
			public const string Edit = prefix + "/Edit";
			public const string Delete = prefix + "/{id}";
		}

		public static class DepartmentRouting
		{
			public const string prefix = Rule + "department";
			public const string list = prefix + "/list";
			public const string id = prefix + "/{id}";
			public const string add = prefix + "/add";
			public const string Edit = prefix + "/Edit";
			public const string Delete = prefix + "/{id}";
		}

		public static class AccountRouting
		{
			public const string prefix = Rule + "account";
			public const string list = prefix + "/list";
			public const string id = prefix + "/{id}";
			public const string register = prefix + "/register";
			public const string Edit = prefix + "/Edit";
			public const string Delete = prefix + "/{id}";
			public const string ChangePassword = prefix + "/ChangePassword";
			public const string SendCode = prefix + "/SendCode";
			public const string VerfiyCode = prefix + "/VerfiyCode";
			public const string ResetPassword = prefix + "/ResetPassword";
			public const string EmailConfirmation = prefix + "/EmailConfirmation";
		}

		public static class Dashboard
		{
			public const string prefix = Rule + "Dashboard";

			public const string register = prefix + "/register";


			public const string GetUserid = prefix + "/User/{id}";
			public const string EditUser = prefix + "/EditUser";
			public const string DeleteUser = prefix + "/DeleteUser/{id}";

			public const string AddRole = prefix + "/AddRole";
			public const string Roleslist = prefix + "/Roleslist";
			public const string EditRole = prefix + "/EditRole";
			public const string DeleteRole = prefix + "/DeleteRole";
		}
		public static class AuthenticationRouting
		{
			public const string prefix = Rule + "Authentication";
			public const string list = prefix + "/list";
			public const string id = prefix + "/{id}";
			public const string register = prefix + "/register";
			public const string Edit = prefix + "/Edit";
			public const string Delete = prefix + "/{id}";
			public const string SignIn = prefix + "/SignIn";
		}

	}
}
