using System;


namespace Shop.Api.Exceptions
{
    public class SecurityException : Exception
    {
        public SecurityException(string message) : base(message)
        {

        }
    }
}
