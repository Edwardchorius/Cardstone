using System;
using System.Collections.Generic;
using System.Text;

namespace Cardstone.Data.Exceptions.CardExceptions
{
    public class InvalidNameException : Exception
    {
        public InvalidNameException(string message) : base(message)
        {

        }
    }
}
