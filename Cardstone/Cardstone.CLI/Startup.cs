using Autofac;
using Cardstone.CLI.Contracts;
using Cardstone.CLI.Core;
using Cardstone.Data.Data;
using Cardstone.Database.Data;
using Cardstone.Services;
using Cardstone.Services.Contracts;
using Cardstone.Services.Contracts.General;
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
            builder.RegisterType<CombatService>().As<ICombatService>();
            builder.RegisterType<PlayersCardsService>().As<IPlayersCardsService>();
            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
            builder.RegisterType<CardstoneContext>().As<IApplicationDbContext>();
            IContainer conteiner = builder.Build();
            IEngine engine = conteiner.Resolve<IEngine>();

            engine.Run();
        }
    }
}
