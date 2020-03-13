using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.SequenceAnalysis
{
    public interface IFindUpperCaseWordsResult
    {
        string FoundWords { get; }
        string OrderBy();
    }
}
