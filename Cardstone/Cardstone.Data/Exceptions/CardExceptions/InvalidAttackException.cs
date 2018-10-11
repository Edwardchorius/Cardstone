using System;
using System.Collections.Generic;
using System.Text;

namespace Cardstone.Data.Exceptions.CardExceptions
{
    public class InvalidAttackException : Exception
    {
        public InvalidAttackException(string message) : base(message)
        {

        }
    }
}
