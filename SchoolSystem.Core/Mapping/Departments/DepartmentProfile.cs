using AutoMapper;
using SchoolProject.Data.Entities;
using SchoolSystem.Core.Features.Departments.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Mapping.Departments
{
	internal class DepartmentProfile : Profile
	{
		public DepartmentProfile()
		{
			CreateMap<Department, ReturnDepartmentResponse>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameEn, src.NameAr)))
				.ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager != null ? src.Manager.Localize(src.Manager.NameEn, src.Manager.NameAr) : string.Empty));
		}
	}
}
