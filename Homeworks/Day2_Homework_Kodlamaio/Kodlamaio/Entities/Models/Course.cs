using Core.Repository.EntityBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models;

public class Course : Entity<Guid>
{
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public Guid InstructorId { get; set; }
    public Instructor Instructor { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public short ComplatedBar { get; set; }


}
