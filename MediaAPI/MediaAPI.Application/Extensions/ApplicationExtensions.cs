using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MediaAPI.Application.Extensions;

public static class ApplicationExtensions
{
    public static void SetupApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}
