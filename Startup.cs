using Autofac;
using Hermes.Identity.Configuration.IoC;
using Hermes.Identity.DbConfiguration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Hermes.Identity
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ContainerModule(Configuration));
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MongoSettings>(
                    Configuration.GetSection(nameof(MongoSettings)));

            services.AddSingleton<IMongoSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoSettings>>().Value);

            services.AddMvc();
            services.AddLogging();
            services.AddControllers();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            MongoConfiguration.Initialize();

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
