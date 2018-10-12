using System.Collections.Generic;
using System.Linq;
using Cardstone.CLI.Contracts;
using Cardstone.Data.Exceptions;
using Cardstone.Services.Contracts;

namespace Cardstone.CLI.Commands
{
    public class PurchaseCardCommand : ICommand
    {
        private IPurchaseService purchaseService;
        private ILogger logger;

        public PurchaseCardCommand(IPurchaseService purchaseService, ILogger logger)
        {
            this.purchaseService = purchaseService;
            this.logger = logger;
        }

        // purchasecard username cardname
        public void Execute(IEnumerable<string> parameters)
        {
            var args = parameters.ToList();

            string username = args[0];
            string cardname = args[1];

            try
            {
                purchaseService.PurchaseCard(username, cardname);
            }
            catch (NotEnoughCoinsException ex)
            {
                logger.AddLog(ex.Message);
            }

            logger.AddLog($"Player {username} purchases {cardname} card successfully");
        }
    }
}
