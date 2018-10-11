using Cardstone.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cardstone.Services.Contracts
{
    public interface ICardService
    {
        Card CreateCard(string name, int attack, int price);

        Card GetCard(string name);
    }
}
