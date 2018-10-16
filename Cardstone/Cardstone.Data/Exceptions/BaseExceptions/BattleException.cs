using System;
using System.Collections.Generic;
using System.Text;

namespace Cardstone.Data.Exceptions.BaseExceptions
{
    public class BattleException :Exception
    {
        public BattleException(string message) : base(message)
        {

        }
    }
}
