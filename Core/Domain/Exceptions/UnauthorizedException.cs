﻿namespace Domain.Exceptions
{
    public sealed class UnauthorizedException(string message = "Invalid Email Or Password") 
        : Exception(message);
  
}
