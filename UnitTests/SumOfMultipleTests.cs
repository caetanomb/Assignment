using FluentAssertions;
using SumOfMultiple;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class SumOfMultipleTests
    {        
        [Theory]
        [InlineData(15, new[] { 3, 6, 9, 12, 15, 5, 10})] //15
        public void Find_All_Numbers_Multiple_Of_3_5_Below_Limit_Provided_Disconsidering_Duplicates(int limit, int[] result)
        {
            //Arrange and act
            var multiples = 
                new FindMultipleNumbersOf3Or5()
                .Handle(limit);
            
            multiples.Multiples.Should().BeEquivalentTo(result);
        }

        [Theory]
        [InlineData(15, 60)] //15
        public void Sum_All_Numbers_Multiple_Of_3_5_Below_Limit_Provided_Disconsidering_Duplicates(int limit, int result)
        {
            //Arrange and act
            var multiples = new[] { 3, 6, 9, 12, 15, 5, 10 };

            var sum = new FindMultipleNumbersResult(multiples).Sum();

            Assert.Equal(result, sum);
        }

        [Theory]
        [InlineData(25, 168)] //15
        //3, 6, 9, 12, 15, 18, 21, 24, 5, 10, 20, 25
        public void Find_And_Sum_All_Numbers_Multiple_Of_3_5_Below_Limit_Provided_Disconsidering_Duplicates(int limit, int result)
        {
            //Arrange and act
            var sum = new FindMultipleNumbersOf3Or5()
                        .Handle(limit)
                        .Sum();

            Assert.Equal(result, sum);
        }
    }
}
