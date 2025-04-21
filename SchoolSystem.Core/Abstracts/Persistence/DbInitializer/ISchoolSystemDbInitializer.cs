using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Abstracts.Persistence.DbInitializer
{
	public interface ISchoolSystemDbInitializer
	{
		Task InitializeAsync();
	}
}
