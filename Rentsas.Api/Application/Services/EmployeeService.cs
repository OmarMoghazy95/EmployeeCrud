using Rentsas.Api.Application.Dtos;
using Rentsas.Api.Core.Entities.Employees;
using Rentsas.Api.Infrastructure;

namespace Rentsas.Api.Application.Services
{
    internal interface IEmployeeService
    {
        Task<EditEmployeeDto> AddAsync(EditEmployeeDto employee, CancellationToken cancellationToken);
        Task<EditEmployeeDto> UpdateAsync(EditEmployeeDto employee, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int Id, CancellationToken cancellationToken);
        Task<EditEmployeeDto> GetById(int Id, CancellationToken cancellationToken);
        Task<PaginationResponse<GetEmployeeDto>> GetAllEmployees(EmployeeFilter filter, CancellationToken cancellationToken);
    }

    internal class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;
        public EmployeeService(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public async Task<EditEmployeeDto> AddAsync(EditEmployeeDto employee, CancellationToken cancellationToken)
        {
            var savedEntity = await _employeeRepo.AddAsync(employee.ToEntity(), cancellationToken);

            if (savedEntity is null || savedEntity is { Id: 0 })
                return default;

            return savedEntity.ToDto();
        }

        public async Task<bool> DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            return await _employeeRepo.DeleteAsync(Id, cancellationToken);
        }

        public async Task<PaginationResponse<GetEmployeeDto>> GetAllEmployees(EmployeeFilter filter, CancellationToken cancellationToken)
        {
            return await _employeeRepo.GetAllEmployees(filter, cancellationToken);
        }

        public async Task<EditEmployeeDto> GetById(int Id, CancellationToken cancellationToken)
        {
            if (Id is 0)
                return default;

            var data = await _employeeRepo.GetById(Id, cancellationToken);

            if (data is null)
                return default;

            return data.ToDto();
        }

        public async Task<EditEmployeeDto> UpdateAsync(EditEmployeeDto employee, CancellationToken cancellationToken)
        {
            var updated = await _employeeRepo.UpdateAsync(employee.ToEntity(), cancellationToken);

            return updated?.ToDto();
        }
    }
}
