using Autofac;
using Hermes.Identity.Settings;
using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Hermes.Identity.Configuration.IoC.Modules
{
    public class ServiceBusModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register((c, p) =>
            {
                var settings = c.Resolve<ServiceBusSettings>();
                //var connectionDetails = MongoClientSettings.FromUrl(new MongoUrl(settings.ConnectionString));
                //connectionDetails.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

                return new QueueClient(connectionDetails);
            }).SingleInstance();

            builder.Register((c, p) =>
            {
                var mongoClient = c.Resolve<ServiceBusModule>();
                var settings = c.Resolve<ServiceBusSettings>();

                var database = mongoClient.GetDatabase(settings.Database);

                return database;
            }).As<IServiceBus>();

            var assembly = typeof(MongoModule)
                .GetTypeInfo()
                .Assembly;
        }
    }
}
