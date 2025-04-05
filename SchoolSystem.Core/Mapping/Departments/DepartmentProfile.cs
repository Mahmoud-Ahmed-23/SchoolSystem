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

			CreateMap<Department, ReturnDepartmentByIdResponse>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
					.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameEn, src.NameAr)))
					.ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager != null ? src.Manager.Localize(src.Manager.NameEn, src.Manager.NameAr) : string.Empty))
					.ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.DepartmentSubjects))
					.ForMember(dest => dest.Instructors, opt => opt.MapFrom(src => src.Instructors))
					.ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students));

			CreateMap<DepartmentSubject, SubjectResponse>()
			  .ForMember(d => d.Id, o => o.MapFrom(src => src.SubjectId))
			  .ForMember(d => d.Name, o => o.MapFrom(src => src.Subject!.Localize(src.Subject.NameEn, src.Subject.NameAr)));

			CreateMap<Instructor, InstructorResponse>()
			 .ForMember(d => d.Id, o => o.MapFrom(src => src.InstructorId))
			 .ForMember(d => d.Name, o => o.MapFrom(src => src.Localize(src.NameEn, src.NameAr)));

			CreateMap<Student, StudentResponse>()
				.ForMember(d => d.Id, o => o.MapFrom(src => src.Id))
				.ForMember(d => d.Name, o => o.MapFrom(src => src.Localize(src.NameEn, src.NameAr)));
		}
	}
}
