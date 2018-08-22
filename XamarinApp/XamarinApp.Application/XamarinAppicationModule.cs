using Autofac;
using XamarinApp.Application.UseCases.Basket;
using XamarinApp.Application.UseCases.Catalog;
using XamarinApp.Application.UseCases.Location;

namespace XamarinApp.Application
{
    public class XamarinAppicationModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CatalogService>().As<ICatalogService>().InstancePerLifetimeScope();
            builder.RegisterType<BasketService>().As<IBasketService>().InstancePerLifetimeScope();
            builder.RegisterType<LocationService>().As<ILocationService>().InstancePerLifetimeScope();
        }
    }
}
