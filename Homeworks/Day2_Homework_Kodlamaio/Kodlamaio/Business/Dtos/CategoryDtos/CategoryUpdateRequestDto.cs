using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.CategoryDtos;

public record CategoryUpdateRequestDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
