namespace Domain.Models.Orders
{
    public class OrderItem : BaseEntity<Guid>
    {
        public OrderItem()
        {
            
        }
        public OrderItem(ProductInOrderItem product, decimal price, decimal quantity)
        {
            Product = product;
            Price = price;
            Quantity = quantity;
        }

        public ProductInOrderItem Product { get; set; } = default!;
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
