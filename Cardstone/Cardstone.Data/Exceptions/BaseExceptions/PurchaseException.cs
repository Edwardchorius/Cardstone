using System;

namespace Cardstone.Data.Exceptions
{
    public class PurchaseException : Exception
    {
        public PurchaseException(string message)
            : base(message)
        {

        }
    }
}
