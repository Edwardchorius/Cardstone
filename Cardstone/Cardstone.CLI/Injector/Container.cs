﻿using Autofac;
using Cardstone.CLI.Commands;
using Cardstone.CLI.Commands.BattleCommads;
using Cardstone.CLI.Commands.CardCommands;
using Cardstone.CLI.Contracts;
using Cardstone.CLI.Core;
using Cardstone.Data.Data;
using Cardstone.Database.Data;
using System.Reflection;

namespace Cardstone.CLI.Injector
{
    public class Container : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            builder.RegisterType<RegisterPlayerCommand>().Named<ICommand>("registerplayer");
            builder.RegisterType<CreateCardCommand>().Named<ICommand>("createcard");
            builder.RegisterType<PurchaseCardCommand>().Named<ICommand>("purchasecard");
            builder.RegisterType<CommenceBattleCommand>().Named<ICommand>("commencebattle");
            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
            builder.RegisterType<CardstoneContext>().As<IApplicationDbContext>();


            // builder.RegisterType<>().Named<ICommand>("");
        }
    }
}
