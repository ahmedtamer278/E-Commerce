using Shared.DataTransferObject;
using Shared.DataTransferObject.Products;

namespace ServicesAbstractions
{
    public interface IProductService
    {
        Task<PaginatedResponse<ProductResponse>> GetAllProductAsync(ProductQueryParameters queryParameters);
        Task<ProductResponse> GetProductAsync(int id);
        Task<IEnumerable<BrandResponse>> GetBrandsAsync();
        Task<IEnumerable<TypeResponse>> GetTypesAsync();
    }
}
