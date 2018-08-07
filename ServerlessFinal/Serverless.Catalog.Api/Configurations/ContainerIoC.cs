using Serverless.Catalog.Api.Services.CatalogItem;
using TinyIoC;

namespace Serverless.Catalog.Api.Configurations
{
    public class ContainerIoC
    {
        private static TinyIoCContainer _container;

        public static bool UseMockService { get; set; }

        static ContainerIoC()
        {
            _container = new TinyIoCContainer();

            // Services - by default, TinyIoC will register interface registrations as singletons.
            _container.Register<ICatalogItemService, CatalogItemService>();
        }

        public static void UpdateDependencies(bool useMockServices)
        {
            // Change injected dependencies
            if (useMockServices)
            {
                //_container.Register<ICatalogService, CatalogMockService>();
                //_container.Register<IBasketService, BasketMockService>();                

                UseMockService = true;
            }
            else
            {
                //_container.Register<ICatalogService, CatalogService>();
                //_container.Register<IBasketService, BasketService>();                

                UseMockService = false;
            }
        }

        public static void RegisterSingleton<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            _container.Register<TInterface, T>().AsSingleton();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }
    }
}
