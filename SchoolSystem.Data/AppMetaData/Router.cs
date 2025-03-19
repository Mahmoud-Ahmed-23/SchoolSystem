using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.AppMetaData
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
			public const string id = prefix + "/{id}";
			public const string add = prefix + "/add";
			public const string Edit = prefix + "/Edit";
			public const string Delete = prefix + "/{id}";
		}
	}
}
