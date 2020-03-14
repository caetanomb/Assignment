using Microsoft.Extensions.DependencyInjection;
using SequenceAnalysis;
using SumOfMultiple;
using System;
using System.Collections.Generic;
using System.Text;

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
            var serviceProvider = StartUp.ConfigureServices();
            ModuleFactory moduleFactory = new ModuleFactory(serviceProvider);

            return moduleFactory;
        }
    }
}
