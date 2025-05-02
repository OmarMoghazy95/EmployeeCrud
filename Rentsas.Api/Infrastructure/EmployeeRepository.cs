using Microsoft.EntityFrameworkCore;
using Rentsas.Api.Application.Dtos;
using Rentsas.Api.Core.Entities.Employees;
using Rentsas.Api.Infrastructure.Context;

namespace Rentsas.Api.Infrastructure
{
    internal interface IEmployeeRepository
    {
        Task<Employee> AddAsync(Employee employee, CancellationToken cancellationToken);
        Task<Employee> UpdateAsync(Employee employee, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int Id, CancellationToken cancellationToken);
        Task<Employee> GetById(int Id, CancellationToken cancellationToken);
        Task<PaginationResponse<GetEmployeeDto>> GetAllEmployees(EmployeeFilter filter, CancellationToken cancellationToken);
    }
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly RentsasDbContext _context;
        private readonly DbSet<Employee> _dbSet;

        public EmployeeRepository(RentsasDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Employee>();
        }

        public async Task<Employee> AddAsync(Employee employee, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(employee, cancellationToken);

            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<bool> DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var result = await _dbSet.Where(a => a.Id == Id).ExecuteDeleteAsync(cancellationToken);

            return result > 0;
        }

        public async Task<PaginationResponse<GetEmployeeDto>> GetAllEmployees(EmployeeFilter filter, CancellationToken cancellationToken)
        {
            var query = _dbSet.OrderByDescending(a => a.Id)
                .AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Search))
                query = query.Where(a => a.FirstName.Contains(filter.Search.Trim()) || a.LastName.Contains(filter.Search.Trim()) || a.Email == filter.Search.Trim());

            if (!string.IsNullOrWhiteSpace(filter.Position))
                query = query.Where(a => a.Position.Contains(filter.Position.Trim()));

            var totalCount = await query.CountAsync(cancellationToken);

            var data = await query.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize)
                .Select(a => new GetEmployeeDto
                {
                    Id = a.Id,
                    Email = a.Email,
                    FullName = $"{a.FirstName} {a.LastName}",
                    Position = a.Position,
                }).ToArrayAsync(cancellationToken);

            return new PaginationResponse<GetEmployeeDto> { TotalCount = totalCount, Data = data };  

        }

        public async Task<Employee> GetById(int Id, CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(a => a.Id == Id, cancellationToken);
        }

        public async Task<Employee> UpdateAsync(Employee employee, CancellationToken cancellationToken)
        {
            _context.Entry(employee).State = EntityState.Modified;

            await _context.SaveChangesAsync(cancellationToken);

            return employee;

        }
    }
}
