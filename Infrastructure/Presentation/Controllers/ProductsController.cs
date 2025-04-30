namespace Presentation.Controllers
{
    
    public class ProductsController (IServiceManager serviceManager)
        : APIController
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
        //[Authorize(Roles = "Admin")]
        [HttpGet("brands")]
        public async Task<ActionResult<BrandResponse>> GetBrands()
        {
            //var email = User.FindFirstValue(ClaimTypes.Email);
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
