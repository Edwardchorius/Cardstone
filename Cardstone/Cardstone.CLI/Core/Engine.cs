using Autofac;
using Cardstone.CLI.Contracts;
using System;
using System.Linq;

namespace Cardstone.CLI.Core
{
    public class Engine : IEngine
    {
        private readonly IComponentContext autofacContext;

        public Engine(IComponentContext autofacContext)
        {
            this.autofacContext = autofacContext;
        }

        public void Run()
        {
            while (true)
            {
                string[] args = Console.ReadLine().Split(' ');

                ICommand command = this.GetCommand(args[0]);

                var parameters = args.Skip(1);

                command.Execute(parameters);
            }
        }


        public ICommand GetCommand(string name)
        {
            return this.autofacContext.ResolveNamed<ICommand>(name);
        }
    }
}
