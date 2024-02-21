using Business.Abstract;
using Business.Dtos.InstructorDtos;
using Core.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstructorsController : BaseController
{
    private readonly IInstructorService _instructorService;

    public InstructorsController(IInstructorService instructorService)
    {
        _instructorService = instructorService;
    }
    [HttpPost("add")]
    public IActionResult Add(InstructorAddRequestDto instructorAddRequestDto)
    {
        Response<InstructorResponseDto> result = _instructorService.TAdd(instructorAddRequestDto);
        return ActionResultInstance(result);
    }
    [HttpPut("update")]
    public IActionResult Update(InstructorUpdateRequestDto instructorToUpdate)
    {
        Response<InstructorResponseDto> result = _instructorService.TUpdate(instructorToUpdate);
        return ActionResultInstance(result);
    }
    [HttpDelete("delete")]
    public IActionResult Delete(Guid id)
    {
        Response<InstructorResponseDto> result = _instructorService.TDelete(id);
        return ActionResultInstance(result);
    }
    [HttpGet("getbyid")]
    public IActionResult GetById(Guid id)
    {
        Response<InstructorResponseDto> result = _instructorService.TGetById(id);
        return ActionResultInstance(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        Response<List<InstructorResponseDto>> result = _instructorService.TGetAll();
        return ActionResultInstance(result);
    }
}
