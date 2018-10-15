using System;

namespace Cardstone.Data.Exceptions
{
    public class CardException : Exception
    {
        public CardException(string message)
            : base(message)
        {

        }
    }
}
