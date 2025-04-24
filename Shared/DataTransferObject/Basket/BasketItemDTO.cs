using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObject.Basket
{
    public record BasketItemDTO 
    {
        public int Id { get; init; }
        public string ProductName { get; init; } = default!;
        public string PictureUrl { get; init; } = default!;
        [Range(1,double.MaxValue)]
        public decimal Price { get; init; }
        [Range(1,99)]
        public decimal Quantity { get; init; }
    }
}
