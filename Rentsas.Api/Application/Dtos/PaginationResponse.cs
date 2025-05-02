namespace Rentsas.Api.Application.Dtos
{
    internal record PaginationResponse<T> 
    {
        public int TotalCount { get; set; }
        public IEnumerable<T> Data { get; set; }

    }
}
