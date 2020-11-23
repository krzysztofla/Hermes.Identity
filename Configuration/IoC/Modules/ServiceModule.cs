using System.Reflection;
using Autofac;
using AutoMapper;
using Hermes.Identity.Auth;
using Hermes.Identity.Common.Markers;
using Hermes.Identity.Services;
using Microsoft.AspNetCore.Identity;

namespace Hermes.Identity.Configuration.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<IService>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterType<Encrypter>()
                   .As<IEncrypter>()
                   .SingleInstance();
        }
    }
}
