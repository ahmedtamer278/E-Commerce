namespace Domain.Exceptions
{
    public  sealed class UserNotFoundException(string email) 
        : NotFoundException($"No User With Email {email} Was Found !");
   
}
