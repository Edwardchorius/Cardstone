using Autofac;
using Cardstone.CLI.Contracts;
using Cardstone.CLI.Core;
using Cardstone.Data.Context;
using Cardstone.Services;
using Cardstone.Services.Contracts;
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
            builder.RegisterType<CardService>().As<ICardService>();
            builder.RegisterType<PurchaseService>().As<IPurchaseService>();
            builder.RegisterType<PlayerService>().As<IPlayerService>();
            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
            builder.RegisterType<CardstoneContext>().As<ICardstoneContext>();
            IContainer conteiner = builder.Build();
            IEngine engine = conteiner.Resolve<IEngine>();

            engine.Run();
        }
    }
}
