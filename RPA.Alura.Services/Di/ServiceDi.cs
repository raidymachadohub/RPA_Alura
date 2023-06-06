using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using RPA.Alura.Services.Services;
using RPA.Alura.Services.Services.Interfaces;

namespace RPA.Alura.Services.Di;

[ExcludeFromCodeCoverage]
public static class ServiceDi
{
    public static IServiceCollection AddServices(this IServiceCollection services)
        => services.AddTransient<IRoutineService, RoutineService>()
                   .AddTransient<ICourseService, CourseService>()
                   .AddTransient<ISeleniumService, SeleniumService>();
}