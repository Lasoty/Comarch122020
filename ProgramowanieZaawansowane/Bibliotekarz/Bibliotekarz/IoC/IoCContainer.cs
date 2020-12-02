using Autofac;
using Bibliotekarz.Services;
using Bibliotekarz.ViewModel;
using Autofac.Extras.DynamicProxy;
using Bibliotekarz.IoC.Interceptors;

namespace Bibliotekarz.IoC
{
    public static class IoCContainer
    {
        public static IContainer Cointainer { get; set; }

        public static void Setup()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<PerformanceLogInterceptor>().AsSelf();

            builder.RegisterType<MainViewModel>()
                .EnableClassInterceptors()
                .InterceptedBy(typeof(PerformanceLogInterceptor)); 

            builder.RegisterType<BookService>().As<IBookService>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(PerformanceLogInterceptor));

            Cointainer = builder.Build();
        }
    }
}
