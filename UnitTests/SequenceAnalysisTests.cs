using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using SequenceAnalysis;

namespace UnitTests
{
    public class SequenceAnalysisTests
    {
        [Theory]
        [InlineData("This IS a STRING", "GIINRSST")]
        [InlineData("This IS a STrING", "IS")]
        [InlineData("This Is a STRInG", "")]
        public void Find_UpperCase_Words_And_Order_them_Alphabetically(string input, string expected)
        {
            //Arrange
            var findUpperWords = new FindUpperCaseWords();

            //Act
            var result = 
                findUpperWords.Handle(input).OrderBy();

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindUpperWordsResult_Throws_ArgumentException_If_Input_Is_Null()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var findUpperCaseWordsResult = new FindUpperCaseWordsResult(null);
            });
        }
    }
}
