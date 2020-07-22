using Autofac;
using Hermes.Identity.Repository;
using Hermes.Identity.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Hermes.Identity.Configuration.IoC.Modules
{
	public class MongoModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.Register((c, p) =>
			{
				var settings = c.Resolve<MongoSettings>();

				return new MongoClient(settings.ConnectionString);
			}).SingleInstance();

			builder.Register((c, p) =>
			{
				var mongoClient = c.Resolve<MongoClient>();
				var settings = c.Resolve<MongoSettings>();
				var database = mongoClient.GetDatabase(settings.Database);

				return database;
			}).As<IMongoDatabase>();

			var assembly = typeof(MongoModule)
				.GetTypeInfo()
				.Assembly;

			builder.RegisterAssemblyTypes(assembly)
				   .Where(x => x.IsAssignableTo<IMongoRepository>())
				   .AsImplementedInterfaces()
				   .InstancePerLifetimeScope();
		}
	}
}
