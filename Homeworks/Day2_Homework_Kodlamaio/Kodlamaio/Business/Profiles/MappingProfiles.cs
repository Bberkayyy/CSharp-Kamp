using AutoMapper;
using Business.Dtos.CategoryDtos;
using Business.Dtos.CourseDtos;
using Business.Dtos.InstructorDtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, CategoryResponseDto>().ReverseMap();
        CreateMap<Category, CategoryAddRequestDto>().ReverseMap();
        CreateMap<Category, CategoryUpdateRequestDto>().ReverseMap();

        CreateMap<Course, CourseResponseDto>()
            .ForMember(x => x.CategoryName, opt => opt.MapFrom(x => x.Category.Name))
            .ForMember(x => x.InstructorName, opt => opt.MapFrom(x => x.Instructor.FirstName + " " + x.Instructor.LastName))
            .ReverseMap();
        CreateMap<Course, CourseAddRequestDto>().ReverseMap();
        CreateMap<Course, CourseUpdateRequestDto>().ReverseMap();

        CreateMap<Instructor, InstructorResponseDto>().ReverseMap();
        CreateMap<Instructor, InstructorAddRequestDto>().ReverseMap();
        CreateMap<Instructor, InstructorUpdateRequestDto>().ReverseMap();
    }
}
