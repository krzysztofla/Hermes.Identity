using Autofac;
using Hermes.Identity.Query;
using System.Reflection;

namespace Hermes.Identity.Configuration.IoC.Modules
{
    public class QueryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IQueryHandler<,>)).InstancePerLifetimeScope();
            builder.RegisterType<QueryDispacher>().As<IQueryDispacher>().InstancePerLifetimeScope();
        }
    }
}
