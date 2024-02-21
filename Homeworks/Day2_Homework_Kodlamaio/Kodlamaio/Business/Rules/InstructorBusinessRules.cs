using Business.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules;

public class InstructorBusinessRules
{
    public void InstructorShouldBeExistWhenRequested(Instructor instructor)
    {
        if (instructor is null) throw new BusinessException(InstuctorExceptionMessages.InstructorShouldBeExistWhenRequestedMessage());
    }
}
