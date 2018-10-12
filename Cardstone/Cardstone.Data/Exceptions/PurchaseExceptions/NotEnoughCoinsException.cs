using System;

namespace Cardstone.Data.Exceptions
{
    public class NotEnoughCoinsException : Exception
    {
        public NotEnoughCoinsException(string message)
            : base(message)
        {

        }
    }
}
