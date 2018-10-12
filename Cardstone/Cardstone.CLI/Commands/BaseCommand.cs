using Cardstone.CLI.Contracts;
using Cardstone.Data.Context;
using System.Collections.Generic;

namespace Cardstone.CLI.Commands
{
    public abstract class BaseCommand : ICommand
    {
        protected ICardstoneContext CardstoneContext { get; }

        public BaseCommand(ICardstoneContext context)
        {
            this.CardstoneContext = context;
        }

        public abstract void Execute(IEnumerable<string> parameters);
    }
}
