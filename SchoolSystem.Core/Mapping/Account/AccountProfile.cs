using AutoMapper;
using SchoolSystem.Core.Features.Accounts.Commands.Models;
using SchoolSystem.Core.Features.Accounts.Results;
using SchoolSystem.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Mapping.Account
{
	public class AccountProfile : Profile
	{
		public AccountProfile()
		{
			CreateMap<AddUserCommand, ApplicationUser>()
				.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
				.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

			CreateMap<ApplicationUser, ReturnUserResponse>();
			CreateMap<EditUserCommand, ApplicationUser>()
				.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
				.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
		}
	}
}
