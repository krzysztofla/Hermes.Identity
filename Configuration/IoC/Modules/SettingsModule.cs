using Autofac;
using Microsoft.Extensions.Configuration;
using Hermes.Identity.Settings;
using Hermes.Identity.Extensions;

namespace Hermes.Identity.Configuration.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration configuration;

        public SettingsModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(configuration.GetSettings<InitialSettings>())
                   .SingleInstance();
            builder.RegisterInstance(configuration.GetSettings<MongoSettings>())
                   .SingleInstance();
            builder.RegisterInstance(configuration.GetSettings<CosmosSettings>())
                   .SingleInstance();
            builder.RegisterInstance(configuration.GetSettings<ServiceBusSettings>())
                   .SingleInstance();
        }
    }
}