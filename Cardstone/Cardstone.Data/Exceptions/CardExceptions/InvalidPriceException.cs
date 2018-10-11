using System;
using System.Collections.Generic;
using System.Text;

namespace Cardstone.Data.Exceptions.CardExceptions
{
    public class InvalidPriceException : Exception
    {
        public InvalidPriceException(string message) : base(message)
        {

        }
    }
}
