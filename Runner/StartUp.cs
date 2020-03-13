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

            serviceCollection.AddSingleton<IFindUpperCaseWords, FindUpperCaseWords>();
            serviceCollection.AddSingleton<IFindMultipleNumbersOf3Or5, FindMultipleNumbersOf3Or5>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
