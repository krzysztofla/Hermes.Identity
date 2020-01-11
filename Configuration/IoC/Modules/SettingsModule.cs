using Autofac;
using Microsoft.Extensions.Configuration;
using Hermes.Identity.DbConfiguration;
using Hermes.Identity.Settings;

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
            builder.RegisterInstance(configuration.Get<InitialSettings>())
                   .SingleInstance();
			builder.RegisterInstance(configuration.Get<MongoSettings>())
	               .SingleInstance();
		}  
    }
}