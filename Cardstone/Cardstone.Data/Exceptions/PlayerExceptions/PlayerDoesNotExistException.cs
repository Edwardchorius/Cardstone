using System;

namespace Cardstone.Data.Exceptions
{
    public class PlayerDoesNotExistException : PlayerException
    {
        public PlayerDoesNotExistException(string message) 
            : base(message)
        {

        }
    }
}
