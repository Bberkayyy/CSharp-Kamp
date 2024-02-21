using Core.Repository.Repositories;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete;

public class InstructorRepository : EFRepositoryBase<BaseDbContext, Instructor, Guid>, IInstructorRepository
{
    public InstructorRepository(BaseDbContext context) : base(context)
    {
    }
}
