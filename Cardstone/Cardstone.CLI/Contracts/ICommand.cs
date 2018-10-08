using System.Collections.Generic;

namespace Cardstone.CLI.Contracts
{
    public interface ICommand
    {
        void Execute(IEnumerable<string> parameters);
    }
}
