using Cardstone.CLI.Contracts;
using Cardstone.Data.Context;
using Cardstone.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cardstone.CLI.Commands.CardCommands
{
    public class CreateCardCommand : ICommand
    {
        private ICardService cardService;

        public CreateCardCommand(ICardService cardService)
        {
            this.cardService = cardService ?? throw new ArgumentNullException(nameof(cardService));
        }

        public void Execute(IEnumerable<string> parameters)
        {
            var args = parameters.ToList();
            
            if (args.Count != 3)
            {
                throw new ArgumentException("Invalid input parameters count passed!");
            }

            string name = args[0];
            int attack = int.Parse(args[1]);
            int price = int.Parse(args[2]);

            try
            {
                var addedCard = this.cardService.CreateCard(name, attack, price);
                Console.WriteLine($"Added card with Id {addedCard.Id}");
            }
            catch (Exception)
            {
                // Custom Exception
            }
        }
    }
}
