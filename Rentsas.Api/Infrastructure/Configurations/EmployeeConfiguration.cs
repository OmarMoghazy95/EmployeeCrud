using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentsas.Api.Core.Entities.Employees;

namespace Rentsas.Api.Infrastructure.Configurations;

internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    void IEntityTypeConfiguration<Employee>.Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a=>a.Id).ValueGeneratedOnAdd();
        builder.Property(a => a.FirstName).HasMaxLength(100);
        builder.Property(a => a.LastName).HasMaxLength(100);
        builder.Property(a => a.Email).HasMaxLength(150);
        builder.Property(a => a.Position).HasMaxLength(150);

    }
}
