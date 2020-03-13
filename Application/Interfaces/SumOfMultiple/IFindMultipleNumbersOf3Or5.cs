using Application.Interfaces.SumOfMultiple;
using System;
using System.Collections.Generic;
using System.Text;

namespace SumOfMultiple
{
    public interface IFindMultipleNumbersOf3Or5
    {
        IFindMultipleNumbersResult Handle(long limit);
    }
}
