using Core.Repository.EntityBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models;

public class Category : Entity<int>
{
    public string Name { get; set; }

    public List<Course> Courses { get; set; }
}
