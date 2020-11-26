using Autofac;
using Hermes.Identity.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Hermes.Identity.Configuration.IoC.Modules
{
    public class EventsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(EventsModule).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IEventHandler<>)).InstancePerLifetimeScope();
            builder.RegisterType<EventDispacher>().As<IEventDispacher>().InstancePerLifetimeScope();
        }
    }
}
