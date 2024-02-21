using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants;

public class InstuctorExceptionMessages
{
    public static string InstructorShouldBeExistWhenRequestedMessage()
    {
        return "Requested instructor does not exist.";
    }
}
