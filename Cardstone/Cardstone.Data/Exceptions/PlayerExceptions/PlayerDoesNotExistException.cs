using System;

namespace Cardstone.Data.Exceptions
{
    public class PlayerDoesNotExistException : Exception
    {
        public PlayerDoesNotExistException(string message) 
            : base(message)
        {

        }
    }
}
