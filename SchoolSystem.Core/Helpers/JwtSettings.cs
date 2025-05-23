﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Helpers
{
	public class JwtSettings
	{
		public string Key { get; set; }
		public string Audience { get; set; }
		public string Issuer { get; set; }
		public double DurationInDays { get; set; }
		public double JWTRefreshTokenExpire { get; set; }

	}
}
