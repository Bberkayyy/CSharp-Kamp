using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants;

public class CourseExceptionMessages
{
    public static string CourseCategoryIdMustBePresentMessage(int categoryId)
    {
        return $"({categoryId}) The entered category id does not present. Please enter a present category id.";
    }
    public static string CourseInstructorIdMustBePresentMessage(Guid instructorId)
    {
        return $"({instructorId}) The entered instructor id does not present. Please enter a present instructor id.";
    }
    public static string CourseNameCanNotBeDuplicatedMessage(string name)
    {
        return $"Course name '{name}' is already exist. Please enter a different course name.";
    }
    public static string CoursePriceCanNotBeNegativeMessage(decimal price)
    {
        return $"Course price can not be negative. Please enter a valid price. ({price})";
    }
    public static string CourseCompletedBarMustBeBetween0And100Message(short completedBar)
    {
        return $"Course completed bar must be 0 between 100. Please enter a valid value. ({completedBar})";
    }
    public static string CourseShouldExistWhenRequestedMessage()
    {
        return "Requested course does not exist.";
    }
}
