using System.Reflection;
using Autofac;
using Hermes.Identity.Command;

namespace Hermes.Identity.Configuration.IoC.Modules
{
    public class CommandModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerLifetimeScope();
            builder.RegisterType<CommandDispacher>().As<ICommandDispacher>().InstancePerLifetimeScope();
        }
    }
}