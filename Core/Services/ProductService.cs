using Services.Specifications;

namespace Services
{
    internal class ProductService (IUnitOfWork unitOfWork , IMapper mapper)
        : IProductService
    {
        public async Task<IEnumerable<ProductResponse>> GetAllProductAsync(int? brandId, int? typeId, ProductSortingOptions options)
        {
            var specifications = new ProductWithBrandAndTypeSpecifications(brandId,typeId,options);
            var product = await unitOfWork.GetRepository<Product, int>().GetAllAsync(specifications);
            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductResponse>>(product);
        }

        public async Task<IEnumerable<BrandResponse>> GetBrandsAsync()
        {
            var repo = unitOfWork.GetRepository<ProductBrand, int>();
            var brands = await repo.GetAllAsync();
            return mapper.Map<IEnumerable<ProductBrand>, IEnumerable<BrandResponse>>(brands);
        }

        public async Task<ProductResponse> GetProductAsync(int id)
        {
            var specifications = new ProductWithBrandAndTypeSpecifications(id);

            var product = await unitOfWork.GetRepository<Product, int>().GetAsync(specifications);
            return mapper.Map<Product ,ProductResponse>(product);
        }

        public async Task<IEnumerable<TypeResponse>> GetTypesAsync()
        {
            var repo = unitOfWork.GetRepository<ProductType, int>();
            var types = await repo.GetAllAsync();
            return mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeResponse>>(types);
            
        }
    }
}
