using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IInstructorRepository, InstructorRepository>();
        return services;
    }
}
