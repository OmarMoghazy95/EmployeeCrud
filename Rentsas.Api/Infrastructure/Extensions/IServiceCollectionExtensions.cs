using Microsoft.EntityFrameworkCore;
using Rentsas.Api.Infrastructure.Context;
using SQLitePCL;

namespace Rentsas.Api.Infrastructure.Extensions;

public static partial class IServiceCollectionExtensions
{

    public static void RegisterDbContext(this IServiceCollection services)
    {
        Batteries.Init();
        services.AddDbContext<RentsasDbContext>(options =>
    options.UseSqlite("Data Source=rentsas.db"));

    }
}
