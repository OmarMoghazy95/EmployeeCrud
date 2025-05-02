using Rentsas.Api.Core.Entities.Employees;

namespace Rentsas.Api.Application.Dtos
{
    internal  record EditEmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }

        public Employee ToEntity() 
        {
            return new Employee 
            {
                Id= Id,
                FirstName= FirstName.Trim(),
                LastName= LastName.Trim(),
                Email= Email.Trim(),
                Position= Position.Trim(), 
            };
        }
    }
}
