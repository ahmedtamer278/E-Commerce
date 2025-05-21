namespace Shared.Orders
{
    public record OrderItemDTO
    {
        public string PictureUrl { get; set; }
        public string ProductName {  get; set; }    
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
