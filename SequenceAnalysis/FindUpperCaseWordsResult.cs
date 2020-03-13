using Application.Interfaces.SequenceAnalysis;
using System;
using System.Linq;

namespace SequenceAnalysis
{
    public class FindUpperCaseWordsResult : IFindUpperCaseWordsResult
    {
        public string FoundWords { get; }

        public FindUpperCaseWordsResult(string stringContent)
        {
            FoundWords = stringContent 
                ?? throw new ArgumentException("Result content cannot be null", nameof(stringContent));
        }

        public string OrderBy()
        {
            return new string(FoundWords.OrderBy(a => a).ToArray());
        }
    }
}