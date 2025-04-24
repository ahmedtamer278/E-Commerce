
namespace Domain.Exceptions
{
    public sealed class BasketNotFoundException (string key) 
        : NotFoundException($"Basket With Key {key} Not Found !! ")
    {
    }
}
