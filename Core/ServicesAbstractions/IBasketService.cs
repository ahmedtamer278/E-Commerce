using Shared.DataTransferObject.Basket;

namespace ServicesAbstractions
{
    public interface IBasketService
    {
        Task<BasketDTO> GetAsync(string id);
        Task<BasketDTO> UpdateAsync(BasketDTO basket);
        Task<bool> DeleteAsync(string id);
    }
}
