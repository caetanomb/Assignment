using System;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = StartUp.ConfigureServices();
            ModuleFactory moduleFactory = new ModuleFactory(serviceProvider);

            while (true)
            {
                Console.WriteLine("\n\n\t *** WAES Assignment *** \n");
                Console.WriteLine("Choose a problem below to solve:");
                Console.WriteLine("  1 - Find the sum of all natural numbers that are a multiple of 3 or 5 below a limit provided");
                Console.WriteLine("  2 - Find the uppercase words and order all characters in these words alphabetically");
                Console.WriteLine(" -------------------------------------------------------------");
                Console.WriteLine("3 - Clear");
                Console.WriteLine("4 - Exit");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        moduleFactory.BuildModule(nameof(MenuOptionsEnum.SumOfMultiple)).Execute();
                        break;
                    case "2":
                        moduleFactory.BuildModule(nameof(MenuOptionsEnum.SequenceAnalysis)).Execute();
                        break;
                    case "3":
                        Console.Clear();
                        break;
                    case "4":
                        Environment.Exit(Environment.ExitCode);
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }
    }
}
