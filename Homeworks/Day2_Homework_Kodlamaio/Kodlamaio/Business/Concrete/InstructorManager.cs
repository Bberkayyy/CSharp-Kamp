using AutoMapper;
using Business.Abstract;
using Business.Dtos.InstructorDtos;
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

namespace Business.Concrete;

public class InstructorManager : IInstructorService
{
    private readonly IInstructorRepository _instructorRepository;
    private readonly IMapper _mapper;
    private readonly InstructorBusinessRules _instructorBusinessRules;

    public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper, InstructorBusinessRules instructorBusinessRules)
    {
        _instructorRepository = instructorRepository;
        _mapper = mapper;
        _instructorBusinessRules = instructorBusinessRules;
    }

    public Response<InstructorResponseDto> TAdd(InstructorAddRequestDto instructorAddRequestDto)
    {
        try
        {
            Instructor instructor = _mapper.Map<Instructor>(instructorAddRequestDto);
            instructor.Id = new Guid();
            _instructorRepository.Add(instructor);
            InstructorResponseDto addedInstructor = _mapper.Map<InstructorResponseDto>(instructor);
            return new Response<InstructorResponseDto>
            {
                Data = addedInstructor,
                Message = "Instructor added successfully.",
                StatusCode = System.Net.HttpStatusCode.Created
            };
        }
        catch (Exception ex)
        {
            return new Response<InstructorResponseDto> { Message = ex.Message, StatusCode = System.Net.HttpStatusCode.BadRequest };
        }

    }

    public Response<InstructorResponseDto> TDelete(Guid id)
    {
        try
        {
            Instructor instructor = _instructorRepository.GetByFilter(x => x.Id == id);
            _instructorBusinessRules.InstructorShouldBeExistWhenRequested(instructor);
            _instructorRepository.Delete(instructor);
            return new Response<InstructorResponseDto>
            {
                Message = "Instructor deleted successfully.",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new Response<InstructorResponseDto> { Message = ex.Message, StatusCode = System.Net.HttpStatusCode.BadRequest };
        }
    }

    public Response<List<InstructorResponseDto>> TGetAll()
    {
        List<Instructor> instructors = _instructorRepository.GetAll();
        List<InstructorResponseDto> data = instructors.Select(x => _mapper.Map<InstructorResponseDto>(x)).ToList();
        return new Response<List<InstructorResponseDto>>
        {
            Data = data,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<InstructorResponseDto> TGetByFilter(Expression<Func<Instructor, bool>> predicate)
    {
        try
        {
            Instructor instructor = _instructorRepository.GetByFilter(predicate);
            _instructorBusinessRules.InstructorShouldBeExistWhenRequested(instructor);
            InstructorResponseDto data = _mapper.Map<InstructorResponseDto>(instructor);
            return new Response<InstructorResponseDto>
            {
                Data = data,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new Response<InstructorResponseDto> { Message = ex.Message, StatusCode = System.Net.HttpStatusCode.BadRequest };
        }
    }

    public Response<InstructorResponseDto> TGetById(Guid id)
    {
        try
        {
            Instructor instructor = _instructorRepository.GetByFilter(x => x.Id == id);
            _instructorBusinessRules.InstructorShouldBeExistWhenRequested(instructor);
            InstructorResponseDto data = _mapper.Map<InstructorResponseDto>(instructor);
            return new Response<InstructorResponseDto>
            {
                Data = data,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new Response<InstructorResponseDto> { Message = ex.Message, StatusCode = System.Net.HttpStatusCode.BadRequest };
        }
    }

    public Response<InstructorResponseDto> TUpdate(InstructorUpdateRequestDto instructorUpdateRequestDto)
    {
        try
        {
            Instructor instructor = _mapper.Map<Instructor>(instructorUpdateRequestDto);
            _instructorRepository.Update(instructor);
            InstructorResponseDto updatedInstructor = _mapper.Map<InstructorResponseDto>(instructor);
            return new Response<InstructorResponseDto>
            {
                Data = updatedInstructor,
                Message = "Instructor updated successfully.",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new Response<InstructorResponseDto> { Message = ex.Message, StatusCode = System.Net.HttpStatusCode.BadRequest };
        }
    }
}
