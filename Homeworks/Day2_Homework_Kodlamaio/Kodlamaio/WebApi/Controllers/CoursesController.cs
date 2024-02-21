using Business.Abstract;
using Business.Dtos.CategoryDtos;
using Business.Dtos.CourseDtos;
using Core.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : BaseController
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] CourseAddRequestDto courseAddRequestDto)
    {
        Response<CourseResponseDto> result = _courseService.TAdd(courseAddRequestDto);
        return ActionResultInstance(result);
    }
    [HttpPut("update")]
    public IActionResult Update([FromBody] CourseUpdateRequestDto courseUpdateRequestDto)
    {
        Response<CourseResponseDto> result = _courseService.TUpdate(courseUpdateRequestDto);
        return ActionResultInstance(result);
    }
    [HttpDelete("delete")]
    public IActionResult Delete([FromQuery] Guid id)
    {
        Response<CourseResponseDto> result = _courseService.TDelete(id);
        return ActionResultInstance(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        Response<List<CourseResponseDto>> result = _courseService.TGetAll();
        return ActionResultInstance(result);
    }
    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery] Guid id)
    {
        Response<CourseResponseDto> resuult = _courseService.TGetById(id);
        return ActionResultInstance(resuult);
    }
}
