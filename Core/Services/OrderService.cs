using Domain.Models.Orders;
using Shared.Orders;

namespace Services
{
    internal class OrderService (IMapper mapper , IUnitOfWork _unitOfWork , IBasketRepository _basketRepository)
        : IOrderService
    {
        public async Task<OrderResponse> CreateAysnc(OrderRequest request, string email)
        {
            var basket = await _basketRepository.GetAsync(request.BasketId)??
                throw new BasketNotFoundException(request.BasketId);
            List<OrderItem> items = [];
            var productRepo = _unitOfWork.GetRepository<Product>();
            foreach (var item in basket.BasketItems)
            {
                var product = await productRepo.GetAsync(item.Id)
                    ?? throw new ProductNotFoundException(item.Id);
                items.Add(CreateOrderItem(product , item));
                item.Price = product.Price;
            }
            var address = mapper.Map<OrderAddress> (request.Address);
            var method = await _unitOfWork.GetRepository<DeliveryMethod>()
                .GetAsync(request.DeliveryMethodId)
                ?? throw new DeliveryMethodNotFoundException(request.DeliveryMethodId);
            var subtotal = items.Sum(x=> x.Quantity * x.Price);
            var order = new Order(email, items, address, method, subtotal);
            _unitOfWork.GetRepository<Order, Guid>().Add(order);
            await _unitOfWork.SavaChangesAsync();

            return mapper.Map<OrderResponse>(order);
        }

        private static OrderItem CreateOrderItem(Product product, BasketItem item)
            => new(new(product.Id , product.Name , product.PictureUrl), product.Price, item.Quantity);

        public async Task<IEnumerable<OrderResponse>> GetAllAsync(string email)
        {
            var orders = await _unitOfWork.GetRepository<Order, Guid>()
                .GetAllAsync(new OrderSpecifications(email));
            return mapper.Map<IEnumerable<OrderResponse>>(orders);
        }

        public async Task<OrderResponse> GetAysnc(Guid id)
        {
            var order = await _unitOfWork.GetRepository<Order, Guid>()
                .GetAsync(new OrderSpecifications(id));

            return mapper.Map<OrderResponse>(order);
        }

        public async Task<IEnumerable<DeliveryMethodResponse>> GetDeliveryMethodAsync()
        {
            var deliverymethods = await _unitOfWork.GetRepository<DeliveryMethod>().GetAllAsync();
            return mapper.Map<IEnumerable<DeliveryMethodResponse>>(deliverymethods);
        }
    }
}
