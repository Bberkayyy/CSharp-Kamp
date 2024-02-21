using Business.Dtos.CourseDtos;
using Core.Shared;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface ICourseService
{
    Response<CourseResponseDto> TAdd(CourseAddRequestDto courseAddRequestDto);
    Response<CourseResponseDto> TUpdate(CourseUpdateRequestDto courseUpdateRequestDto);
    Response<CourseResponseDto> TDelete(Guid id);
    Response<List<CourseResponseDto>> TGetAll();
    Response<CourseResponseDto> TGetById(Guid id);

    Response<CourseResponseDto> TGetByFilter(Expression<Func<Course, bool>> predicate);
}
