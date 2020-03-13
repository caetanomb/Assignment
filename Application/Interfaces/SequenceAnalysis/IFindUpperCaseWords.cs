using Application.Interfaces.SequenceAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace SequenceAnalysis
{
    public interface IFindUpperCaseWords
    {
        IFindUpperCaseWordsResult Handle(string input);
    }
}
