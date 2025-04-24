using Shared.DataTransferObject.Basket;

namespace Presentation.Controllers
{
    public class BasketsController(IServiceManager serviceManager)
        : APIController
    {
        // Ge Basket by Id 
        [HttpGet]
        public async Task<ActionResult<BasketDTO>> Get(string id)
        {
            var basket = await serviceManager.BasketService.GetAsync(id);
            return Ok(basket);
        }
        // Update Basted (BasketDTO) => Create Basket , Add Item To Basket , Remove Item From Basket
        [HttpPost]
        public async Task<ActionResult<BasketDTO>> Update(BasketDTO basket)
        {
            var basketDTO = await serviceManager.BasketService.UpdateAsync(basket);
            return Ok(basketDTO);

        }
        // Delete Basket
        [HttpDelete("{id}")]
        public async Task<ActionResult<BasketDTO>> Delete(string id )
        {
            await serviceManager.BasketService.DeleteAsync(id);
            return NoContent();

        }
    }
}
