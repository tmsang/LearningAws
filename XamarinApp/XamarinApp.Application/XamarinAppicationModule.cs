using Autofac;
using XamarinApp.Application.UseCases.Catalog;

namespace XamarinApp.Application
{
    public class XamarinAppicationModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CatalogService>().As<ICatalogService>().InstancePerLifetimeScope();
        }
    }
}
