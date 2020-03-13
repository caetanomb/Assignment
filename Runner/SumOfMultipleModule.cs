using Application;
using SumOfMultiple;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runner
{
    public class SumOfMultipleModule : IModule
    {
        private readonly IFindMultipleNumbersOf3Or5 _findMultipleNumbersOf3Or5;
        public SumOfMultipleModule(IFindMultipleNumbersOf3Or5 findMultipleNumbersOf3Or5)
        {
            _findMultipleNumbersOf3Or5 = findMultipleNumbersOf3Or5;
        }

        public void Execute()
        {
            Console.WriteLine("Informe a limit value");

            if (!long.TryParse(Console.ReadLine(), out var limit))
            {
                Console.WriteLine("WARNING - Invalid informed value");
                return;
            }

            var result =
                _findMultipleNumbersOf3Or5
                .Handle(limit)
                .Sum();

            Console.WriteLine($"Output: {result}");
        }
    }
}
