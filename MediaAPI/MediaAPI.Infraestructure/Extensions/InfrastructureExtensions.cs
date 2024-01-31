using MediaAPI.Application.Repositories;
using MediaAPI.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediaAPI.Infraestructure.Extensions;

public static class InfrastructureExtensions
{
    public static void SetupInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<MediaAPIContext>(options => options
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddScoped<IMediaRepository, MediaRepository>();
    }
}
