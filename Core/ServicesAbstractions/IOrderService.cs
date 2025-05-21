using Shared.Orders;

namespace ServicesAbstractions
{
    public interface IOrderService
    {
        // create ()
        Task<OrderResponse> CreateAysnc(OrderRequest request, string email);
        Task<OrderResponse> GetAysnc(Guid id);
        Task<IEnumerable<OrderResponse>> GetAllAsync(string email);
        Task<IEnumerable<DeliveryMethodResponse>> GetDeliveryMethodAsync();
    }
}
