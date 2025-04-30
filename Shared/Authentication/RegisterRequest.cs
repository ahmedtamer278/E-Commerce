namespace Shared.Authentication
{
    public record RegisterRequest (string Email, string UserName, string Password, string DisplayName , string PhoneNumber);
   
}
