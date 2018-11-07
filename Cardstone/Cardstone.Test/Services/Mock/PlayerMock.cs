
using System;
using System.Collections.Generic;
using System.Text;

namespace Cardstone.Test.Services.Mock
{
    internal class PlayerMock
    {
        private string username;
        
        public PlayerMock(string username)
        {

        }

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                this.username = value;
            }
        }

        public void GetPlayer(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Invalid value!");
            }
        }
    }
}
