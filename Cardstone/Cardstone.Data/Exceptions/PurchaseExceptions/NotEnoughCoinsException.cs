using System;

namespace Cardstone.Data.Exceptions
{
    public class NotEnoughCoinsException : PurchaseException
    {
        public NotEnoughCoinsException(string message)
            : base(message)
        {

        }
    }
}
