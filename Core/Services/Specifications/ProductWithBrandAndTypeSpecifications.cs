using System.Linq.Expressions;
using Domain.Models.Products;
using Shared.DataTransferObject.Products;

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
        public ProductWithBrandAndTypeSpecifications(ProductQueryParameters Parameters)
            : base(CreateCriteria(Parameters))
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);

            switch (Parameters.Options) 
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
            ApplyPagination(Parameters.PageSize, Parameters.PageIndex);
        }
        private static System.Linq.Expressions.Expression<Func<Product, bool>> CreateCriteria(ProductQueryParameters Parameters)
        {
            return product =>
            (!Parameters.BrandId.HasValue || product.BrandId == Parameters.BrandId.Value) &&
            (!Parameters.TypeId.HasValue || product.TypeId == Parameters.TypeId.Value) && 
            (string.IsNullOrWhiteSpace(Parameters.Search) || 
            product.Name.ToLower().Contains(Parameters.Search.ToLower()));
        }
       
    }
}
