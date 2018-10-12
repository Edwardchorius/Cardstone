using System;

namespace Cardstone.Data.Exceptions
{
    public class CardDoesNotExistException : Exception
    {
        public CardDoesNotExistException(string message) 
            : base(message)
        {

        }
    }
}
