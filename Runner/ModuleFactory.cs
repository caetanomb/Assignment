using Application;
using Application.Modules;
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
            var presenter =
                (IPresenter)_serviceProvider.GetService(typeof(IPresenter));

            if (opt == nameof(MenuOptionsEnum.SequenceAnalysis))
            {
                var requiredService = 
                    (IFindUpperCaseWords)_serviceProvider.GetService(typeof(IFindUpperCaseWords));
                return new SequenceAnalysisModule(requiredService, presenter);
            }
            else if (opt == nameof(MenuOptionsEnum.SumOfMultiple))
            {
                var requiredService =
                    (IFindMultipleNumbersOf3Or5)_serviceProvider.GetService(typeof(IFindMultipleNumbersOf3Or5));
                return new SumOfMultipleModule(requiredService, presenter);
            }

            throw new InvalidOperationException("Module does not exist");
        }
    }
}
