using Autofac;
using XamarinApp.Application.Persistence;
using XamarinApp.Persistence.Basket.Repository;

namespace XamarinApp.Persistence.Basket
{
    public class XamarinPersistenceBasketModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IBasketRepository>().As<RedisBasketRepository>().InstancePerLifetimeScope();
        }
    }
}
