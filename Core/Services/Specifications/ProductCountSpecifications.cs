using System.Linq.Expressions;

namespace Services.Specifications
{
    internal class ProductCountSpecifications(ProductQueryParameters Parameters) : BaseSpecifications<Product>(CreateCriteria(Parameters))
    {
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

