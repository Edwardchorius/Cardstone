using Cardstone.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cardstone.Services.Contracts
{
    public interface ICardService
    {
        Card CreateCard(string Name, int Attack, int Price, string Username);
    }
}
