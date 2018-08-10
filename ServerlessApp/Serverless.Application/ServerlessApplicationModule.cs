using Autofac;
using Serverless.Application.UseCaseCommands.News;
using Serverless.Application.UseCaseCommands.NewsStates;
using Serverless.Application.UseCaseQueries.News;
using Serverless.Application.UseCaseQueries.NewsStates;

namespace Serverless.Application
{
	public class ServerlessApplicationModule: Module
    {
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<GetNewsContentQuery>().As<IGetNewsContentQuery>().InstancePerLifetimeScope();
			builder.RegisterType<GetNewsStatesQuery>().As<IGetNewsStatesQuery>().InstancePerLifetimeScope();

			builder.RegisterType<CreateNewsCommandHandler>().As<ICreateNewsCommandHandler>().InstancePerLifetimeScope();
			builder.RegisterType<UpdateNewsCommandHandler>().As<IUpdateNewsCommandHandler>().InstancePerLifetimeScope();
			builder.RegisterType<DeleteNewsCommandHandler>().As<IDeleteNewsCommandHandler>().InstancePerLifetimeScope();

			builder.RegisterType<CreateNewsStateCommandHandler>().As<ICreateNewsStateCommandHandler>().InstancePerLifetimeScope();
			builder.RegisterType<UpdateNewsStateCommandHandler>().As<IUpdateNewsStateCommandHandler>().InstancePerLifetimeScope();
			builder.RegisterType<DeleteNewsStateCommandHandler>().As<IDeleteNewsStateCommandHandler>().InstancePerLifetimeScope();
		}
	}
}
