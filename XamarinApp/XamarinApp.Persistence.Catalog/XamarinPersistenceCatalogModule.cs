using Autofac;
using XamarinApp.Application.Persistence;
using XamarinApp.Persistence.Catalog.Repositories;

namespace XamarinApp.Persistence.Catalog
{
    public class XamarinPersistenceCatalogModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CatalogRepository>().As<ICatalogRepository>().InstancePerLifetimeScope();
        }
    }
}
