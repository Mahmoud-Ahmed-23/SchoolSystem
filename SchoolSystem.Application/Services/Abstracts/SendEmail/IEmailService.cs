using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Services.Abstracts.SendEmail
{
	public interface IEmailService
	{
		Task SendEmailAsync(EmailDto emailDto);
	}
}
