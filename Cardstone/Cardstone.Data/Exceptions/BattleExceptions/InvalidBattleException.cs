using Cardstone.Data.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cardstone.Data.Exceptions.BattleExceptions
{
    public class InvalidBattleException : BattleException
    {
        public InvalidBattleException(string message) : base(message)
        {

        }
    }
}
