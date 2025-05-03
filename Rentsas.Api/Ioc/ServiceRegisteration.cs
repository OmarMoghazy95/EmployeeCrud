using Rentsas.Api.Application.Services;
using Rentsas.Api.Infrastructure;
using Rentsas.Api.Infrastructure.Extensions;

namespace Rentsas.Api.Ioc;

public static partial class IServiceCollectionExtensions
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.RegisterDbContext();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddCors(options =>
        {
            options.AddPolicy("ClientApp", policy =>
            {
                policy
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        });

    }
}
