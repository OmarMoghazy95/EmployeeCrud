using Rentsas.Api.Application.Dtos;

namespace Rentsas.Api.Core.Entities.Employees;

internal class Employee : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Position { get; set; }

    public EditEmployeeDto ToDto()
    {
        return new EditEmployeeDto
        {
            Email = Email,
            FirstName = FirstName,
            LastName = LastName,
            Id = Id,
            Position = Position
        };
    }
}
