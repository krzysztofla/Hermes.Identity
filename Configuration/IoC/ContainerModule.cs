using Autofac;
using Hermes.Identity.Configuration.IoC.Modules;
using Hermes.Identity.Mapping;
using Microsoft.Extensions.Configuration;

namespace Hermes.Identity.Configuration.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration configuration;

        public ContainerModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(MappingConfig.Initialize())
                   .SingleInstance();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<MongoModule>();
            builder.RegisterModule(new SettingsModule(configuration));
        }          
    }
}