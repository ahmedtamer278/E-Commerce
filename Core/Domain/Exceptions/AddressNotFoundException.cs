namespace Domain.Exceptions
{
    public sealed class AddressNotFoundException(string UserName)
        : NotFoundException($"User {UserName} As No Address")
    {
    }
}
