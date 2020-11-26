using Autofac;
using Hermes.Identity.Services;
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
                return new QueueClient(settings.ConnectionString, settings.QueueName);
            })
            .As<IQueueClient>()
            .InstancePerLifetimeScope();

            var assembly = typeof(ServiceBusModule)
                .GetTypeInfo()
                .Assembly;
        }
    }
}
