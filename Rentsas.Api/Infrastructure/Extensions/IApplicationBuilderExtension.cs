using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rentsas.Api.Infrastructure.Context;

namespace Rentsas.Api.Infrastructure.Extensions;

public static class IApplicationBuilderExtension
{
    public static async Task InitializeDatabase(this IApplicationBuilder app)
    {
        try
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateAsyncScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<RentsasDbContext>();
            await dbContext.Database.MigrateAsync();

        }
        catch (Exception ex)
        {
            throw;

        }

    }
}
