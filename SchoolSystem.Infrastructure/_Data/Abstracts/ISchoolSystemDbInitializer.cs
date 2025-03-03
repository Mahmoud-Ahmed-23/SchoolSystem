using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure._Data.Abstracts
{
	public interface ISchoolSystemDbInitializer
	{
		Task InitializeAsync();
	}
}
