using Business.Abstract;
using Business.Dtos.CategoryDtos;
using Core.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : BaseController
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpPost("add")]
    public IActionResult Add([FromBody] CategoryAddRequestDto categoryAddRequestDto)
    {
        Response<CategoryResponseDto> result = _categoryService.TAdd(categoryAddRequestDto);
        return ActionResultInstance(result);
    }
    [HttpPut("update")]
    public IActionResult Update([FromBody] CategoryUpdateRequestDto categoryUpdateRequestDto)
    {
        Response<CategoryResponseDto> result = _categoryService.TUpdate(categoryUpdateRequestDto);
        return ActionResultInstance(result);
    }
    [HttpDelete("delete")]
    public IActionResult Delete([FromQuery] int id)
    {
        Response<CategoryResponseDto> result = _categoryService.TDelete(id);
        return ActionResultInstance(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        Response<List<CategoryResponseDto>> result = _categoryService.TGetAll();
        return ActionResultInstance(result);
    }
    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery] int id)
    {
        Response<CategoryResponseDto> resuult = _categoryService.TGetById(id);
        return ActionResultInstance(resuult);
    }
}
