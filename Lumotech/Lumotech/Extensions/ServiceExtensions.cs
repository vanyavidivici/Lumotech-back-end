using Contracts;
using LoggerService;

namespace Lumotech.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

    public static void ConfigureLoggerSerivce(this IServiceCollection services)
        => services.AddSingleton<ILoggerManager, LoggerManager>();
}