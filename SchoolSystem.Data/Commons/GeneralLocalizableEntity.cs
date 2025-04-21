using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Commons
{
	public class GeneralLocalizableEntity
	{
		public string Localize(string? en, string? ar)
		{
			CultureInfo culture = Thread.CurrentThread.CurrentCulture;

			if (culture.Name == "ar-EG")
			{
				return ar ?? en ?? string.Empty;
			}
			else
			{
				return en ?? ar ?? string.Empty;
			}
		}
	}
}
