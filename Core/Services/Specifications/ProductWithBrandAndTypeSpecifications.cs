using System.Linq.Expressions;

namespace Services.Specifications
{
    internal class ProductWithBrandAndTypeSpecifications
        : BaseSpecifications<Product>

    {
        // Use Ctor To Create Query To Get Product By Id
        public ProductWithBrandAndTypeSpecifications(int id) 
            : base(product=> product.Id == id)
        {
            // Add includes
            AddInclude(p=>p.ProductType);
            AddInclude(p=>p.ProductBrand);

        }
        // Use Ctor To Create Query To Get  All Product 
        // Use For Sorting & Filtration
        public ProductWithBrandAndTypeSpecifications(int? brandId , int? typeId, ProductSortingOptions options)
            : base(product => 
            (!brandId.HasValue || product.BrandId==brandId.Value)&&
            (!typeId.HasValue || product.TypeId == typeId.Value))
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);

            switch (options) 
            {
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(p=>p.Name);
                        break;
                case ProductSortingOptions.NameDesc:
                    AddOrderByDescending(p => p.Name);
                    break;
                case ProductSortingOptions.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    break;
            }
        }
    }
}
