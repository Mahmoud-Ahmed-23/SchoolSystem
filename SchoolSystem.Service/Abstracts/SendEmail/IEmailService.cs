using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Service.Abstracts.SendEmail
{
	public interface IEmailService
	{
		Task SendEmailAsync(EmailDto emailDto);
	}
}
