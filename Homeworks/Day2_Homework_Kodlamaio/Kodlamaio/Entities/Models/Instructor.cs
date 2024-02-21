using Core.Repository.EntityBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models;

public class Instructor : Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public List<Course> Courses { get; set; }
}
