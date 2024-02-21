using Business.Abstract;
using Business.Concrete;
using Business.Rules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<ICourseService, CourseManager>();
        services.AddScoped<IInstructorService, InstructorManager>();

        services.AddScoped<CategoryBusinessRules>();
        services.AddScoped<CourseBusinessRules>();
        services.AddScoped<InstructorBusinessRules>();
        return services;

    }
}
