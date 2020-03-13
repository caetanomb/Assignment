using Application.Interfaces.SequenceAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SequenceAnalysis
{
    public class FindUpperCaseWords : IFindUpperCaseWords
    {
        public IFindUpperCaseWordsResult Handle(string input)
        {
            List<string> upperWords = new List<string>();

            var words = input.Split(' ');

            //Act
            foreach (var item in words)
            {
                if (item.Any(a => !char.IsUpper(a)))
                    continue;

                upperWords.Add(item);
            }

            return new FindUpperCaseWordsResult(string.Join("", upperWords));
        }
    }
}
