using System.Reflection;
using Autofac;
using Hermes.Identity.DbConfiguration;
using Hermes.Identity.Repository;
using MongoDB.Driver;

namespace Hermes.Identity.Configuration.IoC.Modules
{
    public class MongoModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register((context, props) =>
            {
                var settings = context.Resolve<MongoSettings>();
                return new MongoClient(settings.ConnectionString);
            }).SingleInstance();

            builder.Register((context, props) =>
            {
                var client = context.Resolve<MongoClient>();
                var settings = context.Resolve<MongoSettings>();
                var database = client.GetDatabase(settings.DatabaseName);
                return database;
            }).As<IMongoDatabase>();

            var assembly = typeof(MongoModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<IUserRepository>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}