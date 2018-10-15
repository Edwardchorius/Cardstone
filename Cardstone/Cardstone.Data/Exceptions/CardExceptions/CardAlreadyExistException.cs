using System;

namespace Cardstone.Data.Exceptions
{
    public class CardAlreadyExistException : CardException
    {
        public CardAlreadyExistException(string message)
            : base(message)
        {

        }
    }
}
