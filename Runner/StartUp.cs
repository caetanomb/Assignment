using Application;
using Microsoft.Extensions.DependencyInjection;
using SequenceAnalysis;
using SumOfMultiple;
using System;

namespace Runner
{
    public class StartUp
    {
        public IServiceProvider ServiceProvider { get; private set; }
        public virtual IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IFindUpperCaseWords, FindUpperCaseWords>();
            serviceCollection.AddTransient<IFindMultipleNumbersOf3Or5, FindMultipleNumbersOf3Or5>();
            ConfigurePresenter(serviceCollection);

            return serviceCollection.BuildServiceProvider();
        }

        public virtual ServiceCollection ConfigurePresenter(ServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IPresenter, ConsolePresenter>();

            return serviceCollection;
        }

        public static ModuleFactory Configure()
        {
            //Services
            var serviceProvider = new StartUp().ConfigureServices();
            //Factory
            ModuleFactory moduleFactory = new ModuleFactory(serviceProvider);

            return moduleFactory;
        }
    }
}
