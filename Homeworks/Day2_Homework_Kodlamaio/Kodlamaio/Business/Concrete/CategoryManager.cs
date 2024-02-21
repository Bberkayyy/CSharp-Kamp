using AutoMapper;
using Business.Abstract;
using Business.Dtos.CategoryDtos;
using Business.Rules;
using Core.Shared;
using DataAccess.Repositories.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly CategoryBusinessRules _categoryBusinessRules;

    public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _categoryBusinessRules = categoryBusinessRules;
    }

    public Response<List<CategoryResponseDto>> TGetAll()
    {
        List<Category> categories = _categoryRepository.GetAll();
        List<CategoryResponseDto> data = categories.Select(x => _mapper.Map<CategoryResponseDto>(x)).ToList();
        return new Response<List<CategoryResponseDto>>
        {
            Data = data,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<CategoryResponseDto> TGetByFilter(Expression<Func<Category, bool>> predicate)
    {
        try
        {
            Category category = _categoryRepository.GetByFilter(predicate);
            _categoryBusinessRules.CategoryShouldBeExistWhenRequested(category);
            CategoryResponseDto filteredCategory = _mapper.Map<CategoryResponseDto>(category);
            return new Response<CategoryResponseDto>
            {
                Data = filteredCategory,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new Response<CategoryResponseDto> { Message = ex.Message, StatusCode = System.Net.HttpStatusCode.BadRequest };
        }

    }

    public Response<CategoryResponseDto> TGetById(int id)
    {
        try
        {
            Category category = _categoryRepository.GetByFilter(x => x.Id == id);
            _categoryBusinessRules.CategoryShouldBeExistWhenRequested(category);
            CategoryResponseDto data = _mapper.Map<CategoryResponseDto>(category);
            return new Response<CategoryResponseDto>
            {
                Data = data,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new Response<CategoryResponseDto> { Message = ex.Message, StatusCode = System.Net.HttpStatusCode.BadRequest };
        }

    }

    public Response<CategoryResponseDto> TAdd(CategoryAddRequestDto categoryAddRequestDto)
    {
        try
        {
            _categoryBusinessRules.CategoryNameCanNotBeDuplicated(categoryAddRequestDto.Name);
            Category category = _mapper.Map<Category>(categoryAddRequestDto);
            _categoryRepository.Add(category);
            CategoryResponseDto addedCategory = _mapper.Map<CategoryResponseDto>(category);
            return new Response<CategoryResponseDto>
            {
                Data = addedCategory,
                Message = "Category added successfully.",
                StatusCode = System.Net.HttpStatusCode.Created
            };
        }
        catch (Exception ex)
        {
            return new Response<CategoryResponseDto> { Message = ex.Message, StatusCode = System.Net.HttpStatusCode.BadRequest };
        }



    }

    public Response<CategoryResponseDto> TDelete(int id)
    {
        try
        {
            Category category = _categoryRepository.GetByFilter(x => x.Id == id);
            _categoryBusinessRules.CategoryShouldBeExistWhenRequested(category);
            _categoryRepository.Delete(category);
            CategoryResponseDto deletedCategory = _mapper.Map<CategoryResponseDto>(category);
            return new Response<CategoryResponseDto>
            {
                Data = deletedCategory,
                Message = "Category deleted successfully.",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new Response<CategoryResponseDto> { Message = ex.Message, StatusCode = System.Net.HttpStatusCode.BadRequest };
        }


    }
    public Response<CategoryResponseDto> TUpdate(CategoryUpdateRequestDto categoryUpdateRequestDto)
    {
        try
        {
            _categoryBusinessRules.CategoryNameCanNotBeDuplicated(categoryUpdateRequestDto.Name);
            Category category = _mapper.Map<Category>(categoryUpdateRequestDto);
            _categoryRepository.Update(category);
            CategoryResponseDto updatedCategory = _mapper.Map<CategoryResponseDto>(category);
            return new Response<CategoryResponseDto>
            {
                Data = updatedCategory,
                Message = "Category updated successfully.",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new Response<CategoryResponseDto> { Message = ex.Message, StatusCode = System.Net.HttpStatusCode.BadRequest };
        }

    }
}
