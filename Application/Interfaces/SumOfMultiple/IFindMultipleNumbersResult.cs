using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.SumOfMultiple
{
    public interface IFindMultipleNumbersResult
    {
        IEnumerable<int> Multiples { get; }
        long Sum();
    }
}
