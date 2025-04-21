using Shared.DataTransferObject.Products;

namespace Shared.DataTransferObject
{
    public record PaginatedResponse<TData>(int PageIndex , int PageSize , int TotalCount , IEnumerable<TData>data);
    
}
