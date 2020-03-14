using Application;
using Application.Interfaces.SumOfMultiple;
using Application.Modules;
using Moq;
using SumOfMultiple;
using Xunit;

namespace UnitTests
{
    public class SumOfMultipleModuleTest
    {
        [Fact]
        public void Check_If_Execute_Module_SumOfMultiple_Call_Dependencies()
        {
            //Arrange
            //Mocks
            (var findMultipleNumbersOf3Or5, var findUpperCaseWordsResultMock) = TestHelper.CreateServiceMock();
            var presenterMock = TestHelper.CreatePresenter();

            SumOfMultipleModule sumOfMultipleModule =
               new SumOfMultipleModule(findMultipleNumbersOf3Or5.Object, presenterMock.Object);

            //Act
            sumOfMultipleModule.Execute();

            //Assert that all dependencies has been called
            findMultipleNumbersOf3Or5.Verify(a => a.Handle(It.IsAny<long>()));
            findUpperCaseWordsResultMock.Verify(a => a.Sum());
            presenterMock.Verify(a => a.ShowText(It.IsAny<string>()));
            presenterMock.Verify(a => a.FetchInput());
        }

        public class TestHelper
        {
            public static (Mock<IFindMultipleNumbersOf3Or5>, Mock<IFindMultipleNumbersResult>) CreateServiceMock()
            {
                Mock<IFindMultipleNumbersResult> findMultipleNumbersResultMock = new Mock<IFindMultipleNumbersResult>();
                findMultipleNumbersResultMock.Setup(a => a.Sum())
                    .Verifiable();

                Mock<IFindMultipleNumbersOf3Or5> findMultipleNumbersOf3Or5Mocj = new Mock<IFindMultipleNumbersOf3Or5>();
                findMultipleNumbersOf3Or5Mocj
                    .Setup(a => a.Handle(It.IsAny<long>()))
                    .Returns(() =>
                    {
                        return findMultipleNumbersResultMock.Object;
                    }).Verifiable();

                return (findMultipleNumbersOf3Or5Mocj, findMultipleNumbersResultMock);
            }

            public static Mock<IPresenter> CreatePresenter()
            {
                Mock<IPresenter> presenterMock = new Mock<IPresenter>();
                presenterMock.Setup(a => a.FetchInput())
                    .Returns(() =>
                    {
                        return "15"; //It could be any number
                    })
                    .Verifiable();
                presenterMock.Setup(a => a.ShowText(It.IsAny<string>())).Verifiable();

                return presenterMock;
            }
        }
    }
}
