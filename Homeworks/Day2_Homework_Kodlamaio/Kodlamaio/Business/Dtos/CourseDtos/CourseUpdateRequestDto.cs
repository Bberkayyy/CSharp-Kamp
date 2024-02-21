using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.CourseDtos;

public record CourseUpdateRequestDto
{
    public Guid Id { get; set; }
    public int CategoryId { get; set; }
    public Guid InstructorId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public short ComplatedBar { get; set; }
}
