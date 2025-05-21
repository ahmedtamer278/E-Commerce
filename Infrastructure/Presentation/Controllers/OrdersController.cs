using Shared.Orders;

namespace Presentation.Controllers
{
    [Authorize]
    public class OrdersController(IServiceManager service)
        : APIController
    {
        // Create (address , basketId , deliverymethodId) => OrderResponse
        [HttpPost]
        public async Task<ActionResult<OrderResponse>> Create(OrderRequest request)
        {
            return Ok(await service.OrderService.CreateAysnc(request , GetEmailFromToken()));
        }
        // Get All 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetAll()
        {
            return Ok(await service.OrderService.GetAllAsync(GetEmailFromToken()));
        }
        // Get 
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OrderResponse>> Get(Guid id)
        {
            return Ok(await service.OrderService.GetAysnc(id));
        }
        // GetDeliveryMethods
        [HttpGet("deliveryMethods")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<DeliveryMethodResponse>>> GetDeliveryMethods()
        {
            return Ok(await service.OrderService.GetDeliveryMethodAsync());
        }
    }
}
