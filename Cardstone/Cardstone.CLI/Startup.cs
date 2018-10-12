using Autofac;
using Cardstone.CLI.Contracts;
using Cardstone.CLI.Core;
using Cardstone.Data.Context;
using System.Reflection;

namespace Cardstone.CLI
{
    public class Startup
    {
        public static void Main()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
            builder.RegisterType<CardstoneContext>().As<ICardstoneContext>();
            IContainer conteiner = builder.Build();
            IEngine engine = conteiner.Resolve<IEngine>();

            engine.Run();
        }
    }
}
