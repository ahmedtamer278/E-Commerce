namespace Domain.Exceptions
{
    public sealed class DeliveryMethodNotFoundException(int id)
        : NotFoundException($"No Delivery Method With Id {id} Was Found");
    
}
