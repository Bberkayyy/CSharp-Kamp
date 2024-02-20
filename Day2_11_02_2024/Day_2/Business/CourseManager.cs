using Day_1.Entities;
using Day_2.DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2.Business;

public class CourseManager
{
    private readonly ICourseDal _courseDal;

    public CourseManager(ICourseDal courseDal)
    {
        _courseDal = courseDal;
    }
    public List<Course> GetAll()
    {
        return _courseDal.GetAll();
    }
}
