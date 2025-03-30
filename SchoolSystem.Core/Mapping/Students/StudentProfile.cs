using AutoMapper;
using SchoolProject.Data.Entities;
using SchoolSystem.Core.Features.Students.Commands.Models;
using SchoolSystem.Core.Features.Students.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Mapping.Students
{
	public class StudentProfile : Profile
	{
		public StudentProfile()
		{
			CreateMap<Student, ReturnStudentResponse>()
				.ForMember(dest => dest.DepartmentName, option => option.MapFrom(src => src.Department!.Localize(src.Department!.NameEn, src.Department!.NameAr)))
				.ForMember(dest => dest.Name, option => option.MapFrom(src => src.Localize(src.NameEn, src.NameAr)));

			CreateMap<AddStudentCommand, Student>()
				.ForMember(dest => dest.NameEn, option => option.MapFrom(src => src.Name));

			CreateMap<EditStudentCommand, Student>()
				.ForMember(dest => dest.NameEn, option => option.MapFrom(src => src.Name));

		}
	}
}
