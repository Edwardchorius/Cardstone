using Cardstone.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cardstone.CLI.Commands
{
    public class AddCardToDeckCommand : BaseCommand
    {
        public AddCardToDeckCommand(ICardstoneContext context) : base(context)
        {
        }

        public override void Execute(IEnumerable<string> parameters)
        {
            var args = parameters.ToList();
        }
    }
}
