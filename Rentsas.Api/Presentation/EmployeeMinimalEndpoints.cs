using Microsoft.AspNetCore.Mvc;
using Rentsas.Api.Application.Dtos;
using Rentsas.Api.Application.Services;

namespace Rentsas.Api.Presentation;




public static class EmployeeMinimalEndpoints
{
    public static void MapEmployeeEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/employees");

        group.MapPost("/", async (EditEmployeeDto dto, IEmployeeService service, CancellationToken ct) =>
        {
            var result = await service.AddAsync(dto, ct);
            return Results.Ok(result);
        });

        group.MapPut("/", async (EditEmployeeDto dto, IEmployeeService service, CancellationToken ct) =>
        {
            var result = await service.UpdateAsync(dto, ct);
            return Results.Ok(result);
        });

        group.MapDelete("/{id:int}", async (int id, IEmployeeService service, CancellationToken ct) =>
        {
            var deleted = await service.DeleteAsync(id, ct);
            return deleted ? Results.Ok(deleted) : Results.NotFound(deleted);
        });

        group.MapGet("/{id:int}", async (int id, IEmployeeService service, CancellationToken ct) =>
        {
            var employee = await service.GetById(id, ct);
            return employee != null ? Results.Ok(employee) : Results.NotFound();
        });

        group.MapGet("/", async ([AsParameters]EmployeeFilter filter, IEmployeeService service, CancellationToken ct) =>
        {
            
            var result = await service.GetAllEmployees(filter, ct);
            return Results.Ok(result);
        });
    }
}

