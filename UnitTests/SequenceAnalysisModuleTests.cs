using Application.Interfaces.SequenceAnalysis;
using Moq;
using Runner;
using Runner.Modules;
using SequenceAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class SequenceAnalysisModuleTests
    {
        [Fact]
        public void Check_If_Execute_Module_SequenceAnalysis_Call_Dependencies()
        {
            //Arrange
            //Mocks
            (var findUpperCaseWordsMock, var findUpperCaseWordsResultMock) = TestHelper.CreateServiceMock();
            var presenterMock = TestHelper.CreatePresenter();

             SequenceAnalysisModule sequenceAnalysisModule =
                new SequenceAnalysisModule(findUpperCaseWordsMock.Object, presenterMock.Object);

            //Act
            sequenceAnalysisModule.Execute();

            //Assert that all dependencies has been called
            findUpperCaseWordsMock.Verify(a => a.Handle(It.IsAny<string>()));
            findUpperCaseWordsResultMock.Verify(a => a.OrderBy());
            presenterMock.Verify(a => a.ShowText(It.IsAny<string>()));
            presenterMock.Verify(a => a.FetchInput());
        }

        public class TestHelper
        {
            public static (Mock<IFindUpperCaseWords>, Mock<IFindUpperCaseWordsResult>) CreateServiceMock()
            {
                Mock<IFindUpperCaseWordsResult> findUpperCaseWordsResultMock = new Mock<IFindUpperCaseWordsResult>();
                findUpperCaseWordsResultMock.Setup(a => a.OrderBy())
                    .Verifiable();

                Mock<IFindUpperCaseWords> findUpperCaseWordsMock = new Mock<IFindUpperCaseWords>();
                findUpperCaseWordsMock
                    .Setup(a => a.Handle(It.IsAny<string>()))
                    .Returns(() =>
                    {
                        return findUpperCaseWordsResultMock.Object;
                    }).Verifiable();

                return (findUpperCaseWordsMock, findUpperCaseWordsResultMock);
            }

            public static Mock<IPresenter> CreatePresenter()
            {
                Mock<IPresenter> presenterMock = new Mock<IPresenter>();
                presenterMock.Setup(a => a.FetchInput()).Verifiable();
                presenterMock.Setup(a => a.ShowText(It.IsAny<string>())).Verifiable();

                return presenterMock;
            }
        }
    }
}
