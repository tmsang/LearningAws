using Autofac;
using Serverless.Application.Persistence;
using Serverless.Persistence.Dynamo.Repositories;

namespace Serverless.Persistence.Dynamo
{
	public class ServerlessPersistenceDynamoModule: Module
    {
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ServerlessDbContext>().SingleInstance();
			builder.RegisterType<NewsContentRepository>().As<INewsContentRepository>().InstancePerLifetimeScope();
			builder.RegisterType<NewsStatesRepository>().As<INewsStatesRepository>().InstancePerLifetimeScope();
		}
	}
}
