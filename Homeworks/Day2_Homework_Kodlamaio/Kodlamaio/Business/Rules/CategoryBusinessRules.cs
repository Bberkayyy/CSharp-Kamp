using Business.Constants;
using Core.CrossCuttingConcerns;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Repositories.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules;

public class CategoryBusinessRules
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryBusinessRules(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public void CategoryNameCanNotBeDuplicated(string name)
    {
        Category category = _categoryRepository.GetByFilter(x => x.Name == name);
        if (category is not null) throw new BusinessException(CategoryExceptionMessages.CategoryNameCanNotBeDuplicatedMessage(name));
    }
    public void CategoryShouldBeExistWhenRequested(Category category)
    {
        if (category is null) throw new BusinessException(CategoryExceptionMessages.CategoryShouldExistsWhenRequestedMessage());
    }
}
