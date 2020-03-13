using Application.Interfaces.SumOfMultiple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SumOfMultiple
{
    public class FindMultipleNumbersOf3Or5 : IFindMultipleNumbersOf3Or5
    {
        public IFindMultipleNumbersResult Handle(long limit)
        {
            //It does not add an item if it is already present
            HashSet<int> multiples = new HashSet<int>();

            var numMultiplesOf3 = limit / 3;
            var numMultiplesOf5 = limit / 5;

            var range3 = Enumerable.Range(1, (int)numMultiplesOf3);
            var range5 = Enumerable.Range(1, (int)numMultiplesOf5);

            foreach (var item in range3)
            {
                multiples.Add(item * 3);
            }
            foreach (var item in range5)
            {
                multiples.Add(item * 5);
            }

            return new FindMultipleNumbersResult(multiples);
        }
    }    
}
