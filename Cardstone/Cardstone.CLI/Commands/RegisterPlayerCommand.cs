using Cardstone.CLI.Contracts;
using Cardstone.Data.Context;
using Cardstone.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cardstone.CLI.Commands
{
    public class RegisterPlayerCommand : BaseCommand
    {
        public RegisterPlayerCommand(ICardstoneContext context) : base(context)
        {
        }

        public override void Execute(IEnumerable<string> parameters)
        {
            var args = parameters.ToList();

            if (this.CardstoneContext.Players
                .Any(u => u.Username == args[0]))
            {
                throw new Exception("User already exists!");
            }

            Player user = new Player
            {
                Username = args[0],
                Health = 100,
                XP = 0,
                Coins = 150,
                Deck = new Deck(),
                WonCombats = new List<Combat>(),
                LostCombats = new List<Combat>(),
                Purchases = new List<Purchase>()
                
            };
            this.CardstoneContext.Players.Add(user);
            this.CardstoneContext.SaveChanges();
        }
    }
}
