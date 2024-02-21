using Business.Dtos.InstructorDtos;
using Core.Shared;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IInstructorService
{
    Response<InstructorResponseDto> TAdd(InstructorAddRequestDto instructorAddRequestDto);
    Response<InstructorResponseDto> TUpdate(InstructorUpdateRequestDto instructorUpdateRequestDto);
    Response<InstructorResponseDto> TDelete(Guid id);
    Response<List<InstructorResponseDto>> TGetAll();
    Response<InstructorResponseDto> TGetById(Guid id);

    Response<InstructorResponseDto> TGetByFilter(Expression<Func<Instructor, bool>> predicate);
}
