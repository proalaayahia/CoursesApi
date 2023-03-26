using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CoursesApi.Infrastructure;
namespace CoursesApi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
        return services;
    }
}
