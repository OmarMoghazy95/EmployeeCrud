using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Rentsas.Api.Infrastructure.Context;

public class RentsasDbContext:DbContext
{
    public RentsasDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        base.OnModelCreating(modelBuilder);


    }
}
