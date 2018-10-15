using System;

namespace Cardstone.Data.Exceptions
{
    public class InvalidNameException : CardException
    {
        public InvalidNameException(string message)
            : base(message)
        {

        }
    }
}
