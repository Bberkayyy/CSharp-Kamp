using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants;

public class CategoryExceptionMessages
{
    public static string CategoryNameCanNotBeDuplicatedMessage(string name)
    {
        return $"Category name '{name}' is already exist. Please enter a different category name";
    }
    public static string CategoryShouldExistsWhenRequestedMessage()
    {
        return "Requested category does not exist.";
    }
}
