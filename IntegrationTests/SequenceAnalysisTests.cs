using Runner;
using System;
using Xunit;

namespace IntegrationTests
{
    public class SequenceAnalysisTests
    {
        [Fact]
        public void IntegrationTest_Find_UpperCase_Words_And_Order_them_Alphabetically()
        {
            //Arrange
            TestPresenter testPresenter = new TestPresenter();
            testPresenter.FetchedInput = "This IS a STRING";

            IntegrationTestStartUp startUp = new IntegrationTestStartUp(testPresenter);
            ModuleFactory moduleFactory = startUp.Configure();

            //Act
            var sequenceAnalysisModule = moduleFactory.BuildModule(nameof(MenuOptionsEnum.SequenceAnalysis));
            sequenceAnalysisModule.Execute();

            //Assert
            Assert.NotEmpty(testPresenter.ShowedText);
            Assert.Contains("GIINRSST", testPresenter.ShowedText);
        }
    }
}
