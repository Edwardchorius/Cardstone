using System;

namespace Cardstone.Data.Exceptions
{
    public class PlayerException : Exception
    {
        public PlayerException(string message)
            : base(message)
        {

        }
    }
}
