using Application.Interfaces.SumOfMultiple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SumOfMultiple
{
    public class FindMultipleNumbersResult : IFindMultipleNumbersResult
    {
        public IEnumerable<int> Multiples { get; }

        public FindMultipleNumbersResult(IEnumerable<int> multiples)
        {
            Multiples = multiples;
        }        

        public long Sum()
        {
            return Multiples.Sum();
        }
    }
}
