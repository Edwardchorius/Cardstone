﻿using System;

namespace Cardstone.Data.Exceptions
{
    public class InvalidPriceException : Exception
    {
        public InvalidPriceException(string message) 
            : base(message)
        {

        }
    }
}