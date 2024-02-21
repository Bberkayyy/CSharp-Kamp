using AutoMapper;
using Business.Abstract;
using Business.Dtos.CourseDtos;
using Business.Rules;
using Core.Shared;
using DataAccess.Repositories.Abstract;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class CourseManager : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;
    private readonly CourseBusinessRules _courseBusinessRules;

    public CourseManager(ICourseRepository courseRepository, IMapper mapper, CourseBusinessRules courseBusinessRules)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
        _courseBusinessRules = courseBusinessRules;
    }

    public Response<CourseResponseDto> TAdd(CourseAddRequestDto courseAddRequestDto)
    {
        try
        {
            _courseBusinessRules.CourseCategoryIdMustBePresent(courseAddRequestDto.CategoryId);
            _courseBusinessRules.CourseInstructorIdMustBePresent(courseAddRequestDto.InstructorId);
            _courseBusinessRules.CourseNameCanNotBeDuplicated(courseAddRequestDto.Name);
            _courseBusinessRules.CoursePriceCanNotBeNegative(courseAddRequestDto.Price);
            _courseBusinessRules.CourseCompletedBarMustBeBetween0And100(courseAddRequestDto.ComplatedBar);
            Course course = _mapper.Map<Course>(courseAddRequestDto);
            course.Id = new Guid();
            _courseRepository.Add(course);
            CourseResponseDto addedCourse = _mapper.Map<CourseResponseDto>(course);
            return new Response<CourseResponseDto>
            {
                Data = addedCourse,
                Message = "Course added successfully",
                StatusCode = System.Net.HttpStatusCode.Created
            };

        }
        catch (Exception ex)
        {
            return new Response<CourseResponseDto> { Message = ex.Message, StatusCode = System.Net.HttpStatusCode.BadRequest };
        }
    }

    public Response<CourseResponseDto> TDelete(Guid id)
    {
        try
        {
            Course course = _courseRepository.GetByFilter(x => x.Id == id);
            _courseBusinessRules.CourseShouldBeExistWhenRequested(course);
            _courseRepository.Delete(course);
            return new Response<CourseResponseDto>
            {
                Message = "Course deleted successfully.",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new Response<CourseResponseDto> { Message = ex.Message, StatusCode = System.Net.HttpStatusCode.BadRequest };
        }
    }

    public Response<List<CourseResponseDto>> TGetAll()
    {
        List<Course> courses = _courseRepository.GetAll(include: x => x.Include(x => x.Category).Include(x => x.Instructor));
        List<CourseResponseDto> data = courses.Select(x => _mapper.Map<CourseResponseDto>(x)).ToList();
        return new Response<List<CourseResponseDto>>
        {
            Data = data,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<CourseResponseDto> TGetByFilter(Expression<Func<Course, bool>> predicate)
    {
        try
        {
            Course course = _courseRepository.GetByFilter(predicate);
            _courseBusinessRules.CourseShouldBeExistWhenRequested(course);
            CourseResponseDto filteredCourse = _mapper.Map<CourseResponseDto>(course);
            return new Response<CourseResponseDto>
            {
                Data = filteredCourse,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new Response<CourseResponseDto> { Message = ex.Message, StatusCode = System.Net.HttpStatusCode.BadRequest };
        }
    }

    public Response<CourseResponseDto> TGetById(Guid id)
    {
        try
        {
            Course course = _courseRepository.GetByFilter(x => x.Id == id);
            _courseBusinessRules.CourseShouldBeExistWhenRequested(course);
            CourseResponseDto data = _mapper.Map<CourseResponseDto>(course);
            return new Response<CourseResponseDto>
            {
                Data = data,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new Response<CourseResponseDto> { Message = ex.Message, StatusCode = System.Net.HttpStatusCode.BadRequest };
        }
    }

    public Response<CourseResponseDto> TUpdate(CourseUpdateRequestDto courseUpdateRequestDto)
    {
        try
        {
            _courseBusinessRules.CourseNameCanNotBeDuplicated(courseUpdateRequestDto.Name);
            _courseBusinessRules.CoursePriceCanNotBeNegative(courseUpdateRequestDto.Price);
            _courseBusinessRules.CourseCategoryIdMustBePresent(courseUpdateRequestDto.CategoryId);
            _courseBusinessRules.CourseInstructorIdMustBePresent(courseUpdateRequestDto.InstructorId);
            _courseBusinessRules.CourseCompletedBarMustBeBetween0And100(courseUpdateRequestDto.ComplatedBar);
            Course course = _mapper.Map<Course>(courseUpdateRequestDto);
            _courseRepository.Update(course);
            CourseResponseDto updatedCourse = _mapper.Map<CourseResponseDto>(course);
            return new Response<CourseResponseDto>
            {
                Data = updatedCourse,
                Message = "Course updated successfully.",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new Response<CourseResponseDto> { Message = ex.Message, StatusCode = System.Net.HttpStatusCode.BadRequest };
        }
    }
}
