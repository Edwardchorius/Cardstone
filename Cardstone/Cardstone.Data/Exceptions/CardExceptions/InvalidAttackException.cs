using System;

namespace Cardstone.Data.Exceptions
{
    public class InvalidAttackException : CardException
    {
        public InvalidAttackException(string message) 
            : base(message)
        {

        }
    }
}
