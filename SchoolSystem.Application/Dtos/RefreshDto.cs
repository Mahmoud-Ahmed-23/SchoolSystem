using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Dtos
{
	public class RefreshDto
	{
		public string Token { get; set; }
		public string RefreshToken { get; set; }

		public string Status { get; set; }
	}
}
