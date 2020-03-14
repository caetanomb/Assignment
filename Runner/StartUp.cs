using Application;
using Microsoft.Extensions.DependencyInjection;
using SequenceAnalysis;
using SumOfMultiple;
using System;

namespace Runner
{
    public class StartUp
    {
        public static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IFindUpperCaseWords, FindUpperCaseWords>();
            serviceCollection.AddTransient<IFindMultipleNumbersOf3Or5, FindMultipleNumbersOf3Or5>();
            serviceCollection.AddTransient<IPresenter, ConsolePresenter>();

            return serviceCollection.BuildServiceProvider();
        }

        public static ModuleFactory Configure()
        {
            //Services
            var serviceProvider = StartUp.ConfigureServices();
            //Factory
            ModuleFactory moduleFactory = new ModuleFactory(serviceProvider);

            return moduleFactory;
        }
    }
}
