using Application;
using SequenceAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runner
{
    public class SequenceAnalysisModule : IModule
    {
        private readonly IFindUpperCaseWords _findUpperCaseWords;
        public SequenceAnalysisModule(IFindUpperCaseWords findUpperCaseWords)
        {
            _findUpperCaseWords = findUpperCaseWords;
        }

        public void Execute()
        {
            Console.WriteLine("Informe a string value");

            var stringContent = Console.ReadLine();

            var result = 
                _findUpperCaseWords
                .Handle(stringContent)
                .OrderBy();

            Console.WriteLine($"Output: {result}");
        }
    }
}
