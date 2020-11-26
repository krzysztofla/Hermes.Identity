using System.Reflection;
using Autofac;
using Hermes.Identity.Repository;

namespace Hermes.Identity.Configuration.IoC.Modules
{
    public class SqlServerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(SqlServerModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<IUserRepository>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}