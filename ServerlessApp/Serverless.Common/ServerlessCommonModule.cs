using Autofac;
using Serverless.Common.Xmls;

namespace Serverless.Common
{
	public class ServerlessCommonModule: Module
    {
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<XmlService>().As<IXmlService>().InstancePerLifetimeScope();
		}
	}
}
