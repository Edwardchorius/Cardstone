using System;

namespace Cardstone.Data.Exceptions
{
    public class InvalidAttackException : Exception
    {
        public InvalidAttackException(string message) 
            : base(message)
        {

        }
    }
}
