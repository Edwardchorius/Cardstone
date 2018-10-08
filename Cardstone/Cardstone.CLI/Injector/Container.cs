using Autofac;
using Cardstone.CLI.Contracts;
using Cardstone.CLI.Core;
using System.Reflection;

namespace Cardstone.CLI.Injector
{
    public class Container : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
            // builder.RegisterType<>().Named<ICommand>("");
        }
    }
}
