namespace Rentsas.Api.Application.Dtos
{
    internal record  GetEmployeeDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
    }
}
