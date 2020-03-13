using Application;
using Runner.Modules;
using SequenceAnalysis;
using SumOfMultiple;
using System;

namespace Runner
{
    public class ModuleFactory : IModuleFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ModuleFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IModule BuildModule(string opt)
        {
            if (opt == "SequenceAnalysis")
            {
                var requiredService = 
                    (IFindUpperCaseWords)_serviceProvider.GetService(typeof(IFindUpperCaseWords));
                return new SequenceAnalysisModule(requiredService);
            }
            else if (opt == "SumOfMultiple")
            {
                var requiredService =
                    (IFindMultipleNumbersOf3Or5)_serviceProvider.GetService(typeof(IFindMultipleNumbersOf3Or5));
                return new SumOfMultipleModule(requiredService);
            }

            throw new InvalidOperationException("Module does not exist");
        }
    }
}
