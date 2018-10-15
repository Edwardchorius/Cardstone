﻿using System;

namespace Cardstone.Data.Exceptions
{
    public class InvalidPriceException : CardException
    {
        public InvalidPriceException(string message) 
            : base(message)
        {

        }
    }
}
