using Autofac;
using Hermes.Identity.Repository;
using Hermes.Identity.Settings;
using Microsoft.Azure.Cosmos;
using MongoDB.Driver;
using System.Linq;
using System.Reflection;
using System.Security.Authentication;

namespace Hermes.Identity.Configuration.IoC.Modules
{
    public class CosmosModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register((c, p) =>
            {
                var settings = c.Resolve<CosmosSettings>();

                return new CosmosClient(settings.ConnectionString);
            }).SingleInstance();

            builder.Register((c, p) =>
            {
                var cosmosClient = c.Resolve<CosmosClient>();
                var settings = c.Resolve<CosmosSettings>();

                var database = cosmosClient.GetContainer(settings.Database, settings.Container);

                return database;
            }).As<Container>();

            var assembly = typeof(CosmosModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<ICosmosRepository>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}
