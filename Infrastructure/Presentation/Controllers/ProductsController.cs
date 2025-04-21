using Microsoft.AspNetCore.Mvc;
using ServicesAbstractions;
using Shared.DataTransferObject;
using Shared.DataTransferObject.Products;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController (IServiceManager serviceManager)
        : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedResponse<ProductResponse>>> GetAllProduct([FromQuery]ProductQueryParameters queryParameters)
        {
            var product = await serviceManager.ProductService.GetAllProductAsync(queryParameters);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetProduct(int id)
        {
            var product = await serviceManager.ProductService.GetProductAsync(id);
            return Ok(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<BrandResponse>> GetBrands()
        {
            var brands = await serviceManager.ProductService.GetBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<TypeResponse>> GetTypes()
        {
            var types = await serviceManager.ProductService.GetTypesAsync();
            return Ok(types);
        }
    }
}
