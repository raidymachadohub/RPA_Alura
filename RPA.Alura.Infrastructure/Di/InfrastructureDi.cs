using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RPA.Alura.Infrastructure.Context;
using RPA.Alura.Infrastructure.Facade;
using RPA.Alura.Infrastructure.Facade.Interfaces;
using RPA.Alura.Infrastructure.Repositories;
using RPA.Alura.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Hosting;

namespace RPA.Alura.Infrastructure.Di;

[ExcludeFromCodeCoverage]
public static class InfrastructureDi
{
    // Transient objects are always different; a new instance is provided to every controller and every service.
    // Scoped objects are the same within a request, but different across different requests.
    // Singleton objects are the same for every object and every request.
    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services.AddTransient<IRoutineRepository, RoutineRepository>()
                .AddTransient<ICourseRepository, CourseRepository>();

    public static IServiceCollection AddFacades(this IServiceCollection services) =>
        services.AddTransient<ISeleniumFacade, SeleniumFacade>();
    public static IServiceCollection AddAutoMapper(this IServiceCollection services) =>
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    public static void AddRPAContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RPAAluraDB");
        if (connectionString == null)
            throw new ArgumentNullException(nameof(connectionString));
        services.AddDbContext<RPAContext>(options => options.UseSqlite(connectionString));
    }
    public static IHost AddMigration(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<RPAContext>();
        context.Database.Migrate();
        return host;
    }
}