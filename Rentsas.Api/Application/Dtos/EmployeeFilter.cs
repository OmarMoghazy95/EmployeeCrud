namespace Rentsas.Api.Application.Dtos
{
    internal record class EmployeeFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
        public string Position { get; set; }
    }
}
