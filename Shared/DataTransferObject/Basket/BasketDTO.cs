namespace Shared.DataTransferObject.Basket
{
    public record BasketDTO
    {
        public string Id { get; init; }
        public ICollection<BasketItemDTO> BasketItems { get; init; } = [];
    }
}
