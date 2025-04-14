using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolSystem.Core._SharedResources;
using SchoolSystem.Core.Bases;
using SchoolSystem.Core.Features.Emails.Commands.Models;
using SchoolSystem.Data.Entities.Identity;
using SchoolSystem.Service.Abstracts.SendEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Features.Emails.Commands.Handlers
{
	public class EmailsCommandHandler :
		ResponseHandler,
		IRequestHandler<SendCodeCommand, Response<string>>,
		IRequestHandler<VerifyCodeByEmailCommand, Response<string>>,
		IRequestHandler<ResetPasswordCommand, Response<string>>,
		IRequestHandler<ConfirmEmailCommand, Response<string>>
	{
		private readonly IStringLocalizer<SharedResources> _localizer;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IEmailService _emailService;

		public EmailsCommandHandler(IStringLocalizer<SharedResources> localizer, UserManager<ApplicationUser> userManager, IEmailService emailService)
			: base(localizer)
		{
			_localizer = localizer;
			_userManager = userManager;
			_emailService = emailService;
		}

		public async Task<Response<string>> Handle(SendCodeCommand request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);

			if (user is null)
				return NotFound<string>(_localizer[SharedResourcesKeys.EmailNotFound]);

			var resetCode = RandomNumberGenerator.GetInt32(100_0, 999_9);

			var ResetCodeExpire = DateTime.UtcNow.AddMinutes(15);

			user.EmailConfirmResetCode = resetCode;
			user.EmailConfirmResetCodeExpiry = ResetCodeExpire;

			var result = await _userManager.UpdateAsync(user);

			if (!result.Succeeded)
				return BadRequest<string>(_localizer[SharedResourcesKeys.EmailNotSent]);

			var Email = new EmailDto()
			{
				To = request.Email,
				Subject = "Reset Code For School System Account",
				Body = $"We Have Recived Your Request For Reset Your Account Password, \nYour Reset Code Is ==> [ {resetCode} ] <== \nNote: This Code Will Be Expired After 15 Minutes!",
			};

			await _emailService.SendEmailAsync(Email);

			return Success(resetCode.ToString(), _localizer[SharedResourcesKeys.EmailSent]);
		}

		public async Task<Response<string>> Handle(VerifyCodeByEmailCommand request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);

			if (user is null)
				return BadRequest<string>(_localizer[SharedResourcesKeys.EmailNotFound]);

			if (user.EmailConfirmResetCode != request.resetCode)
				return BadRequest<string>(_localizer[SharedResourcesKeys.InvalidResetCode]);

			if (user.EmailConfirmResetCodeExpiry < DateTime.UtcNow)
				return BadRequest<string>(_localizer[SharedResourcesKeys.ResetCodeExpired]);

			return Success<string>(_localizer[SharedResourcesKeys.Success]);
		}

		public async Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);

			if (user is null)
				return BadRequest<string>(_localizer[SharedResourcesKeys.EmailNotFound]);

			var RemovePass = await _userManager.RemovePasswordAsync(user);

			if (!RemovePass.Succeeded)
				return BadRequest<string>("Something Went Wrong While Reseting Your Password");

			var newPass = await _userManager.AddPasswordAsync(user, request.newPassword);

			if (!newPass.Succeeded)
				return BadRequest<string>("Something Went Wrong While Reseting Your Password");

			return Success<string>(_localizer[SharedResourcesKeys.Success]);
		}

		public async Task<Response<string>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);

			if (user is null)
				return BadRequest<string>(_localizer[SharedResourcesKeys.EmailNotFound]);

			if (user.EmailConfirmResetCode != request.ConfirmationCode)
				return BadRequest<string>(_localizer[SharedResourcesKeys.InvalidResetCode]);

			if (user.EmailConfirmResetCodeExpiry < DateTime.UtcNow)
				return BadRequest<string>(_localizer[SharedResourcesKeys.ResetCodeExpired]);

			user.EmailConfirmed = true;

			var result = await _userManager.UpdateAsync(user);

			if (!result.Succeeded)
				return BadRequest<string>(_localizer[SharedResourcesKeys.EmailNotConfirmed]);

			return Success<string>(_localizer[SharedResourcesKeys.EmailConfirmed]);
		}
	}
}
