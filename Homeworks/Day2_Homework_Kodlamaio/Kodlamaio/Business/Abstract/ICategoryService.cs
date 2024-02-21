using Business.Dtos.CategoryDtos;
using Core.Shared;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface ICategoryService
{
    Response<CategoryResponseDto> TAdd(CategoryAddRequestDto categoryAddRequestDto);
    Response<CategoryResponseDto> TUpdate(CategoryUpdateRequestDto categoryUpdateRequestDto);
    Response<CategoryResponseDto> TDelete(int id);
    Response<List<CategoryResponseDto>> TGetAll();
    Response<CategoryResponseDto> TGetById(int id);

    Response<CategoryResponseDto> TGetByFilter(Expression<Func<Category, bool>> predicate);
}
