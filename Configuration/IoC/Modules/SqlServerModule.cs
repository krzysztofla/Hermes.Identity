using System.Reflection;
using Autofac;
using Hermes.Identity.DbConfiguration;
using Hermes.Identity.Repository;
using MongoDB.Driver;

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