using Business.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Repositories.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules;

public class CourseBusinessRules
{
    private readonly ICourseRepository _courseRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IInstructorRepository _instructorRepository;

    public CourseBusinessRules(ICourseRepository courseRepository, ICategoryRepository categoryRepository, IInstructorRepository instructorRepository)
    {
        _courseRepository = courseRepository;
        _categoryRepository = categoryRepository;
        _instructorRepository = instructorRepository;
    }

    public void CourseCategoryIdMustBePresent(int categoryId)
    {
        Category category = _categoryRepository.GetByFilter(x => x.Id == categoryId);
        if (category is null) throw new BusinessException(CourseExceptionMessages.CourseCategoryIdMustBePresentMessage(categoryId));
    }

    public void CourseInstructorIdMustBePresent(Guid instructorId)
    {
        Instructor instructor = _instructorRepository.GetByFilter(x => x.Id == instructorId);
        if (instructor is null) throw new BusinessException(CourseExceptionMessages.CourseInstructorIdMustBePresentMessage(instructorId));
    }
    public void CourseNameCanNotBeDuplicated(string name)
    {
        Course course = _courseRepository.GetByFilter(x => x.Name == name);
        if (course is not null) throw new BusinessException(CourseExceptionMessages.CourseNameCanNotBeDuplicatedMessage(name));
    }
    public void CoursePriceCanNotBeNegative(decimal price)
    {
        if (price < 0) throw new BusinessException(CourseExceptionMessages.CoursePriceCanNotBeNegativeMessage(price));
    }
    public void CourseCompletedBarMustBeBetween0And100(short completedBar)
    {
        if (completedBar < 0 || completedBar > 100) throw new BusinessException(CourseExceptionMessages.CourseCompletedBarMustBeBetween0And100Message(completedBar));
    }
    public void CourseShouldBeExistWhenRequested(Course course)
    {
        if (course is null) throw new BusinessException(CourseExceptionMessages.CourseShouldExistWhenRequestedMessage());
    }
}
