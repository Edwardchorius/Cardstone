using System;

namespace Cardstone.Data.Exceptions
{
    public class CardDoesNotExistException : CardException
    {
        public CardDoesNotExistException(string message) 
            : base(message)
        {

        }
    }
}
