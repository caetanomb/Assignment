using Application;
using Microsoft.Extensions.DependencyInjection;
using Runner;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests
{
    public class IntegrationTestStartUp : StartUp
    {
        private readonly TestPresenter _testPresenterMock;
        public IntegrationTestStartUp(TestPresenter testPresenterMock)
        {
            _testPresenterMock = testPresenterMock;
        }
        public override ServiceCollection ConfigurePresenter(ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IPresenter>(_testPresenterMock);

            return serviceCollection;
        }

        public new ModuleFactory Configure()
        {
            //Services
            var serviceProvider = ConfigureServices();
            //Factory
            ModuleFactory moduleFactory = new ModuleFactory(serviceProvider);

            return moduleFactory;
        }
    }
}
