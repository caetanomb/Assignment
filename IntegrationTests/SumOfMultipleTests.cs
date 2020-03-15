using Runner;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegrationTests
{
    public class SumOfMultipleTests
    {
        [Fact]
        public void IntegrationTest_Find_And_Sum_All_Numbers_Multiple_Of_3_5_Below_Limit()
        {
            //Arrange
            TestPresenter testPresenter = new TestPresenter();
            testPresenter.FetchedInput = "25";
            var expectedResult = 168;

            IntegrationTestStartUp startUp = new IntegrationTestStartUp(testPresenter);
            ModuleFactory moduleFactory = startUp.Configure();

            //Act
            var sequenceAnalysisModule = moduleFactory.BuildModule(nameof(MenuOptionsEnum.SumOfMultiple));
            sequenceAnalysisModule.Execute();

            Assert.NotEmpty(testPresenter.ShowedText);
            Assert.Equal($"Output: {expectedResult}", testPresenter.ShowedText);
        }
    }
}
