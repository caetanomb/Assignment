using Application;
using System;

namespace Runner
{
    class ConsolePresenter : IPresenter
    {
        public string FetchInput()
        {
            return Console.ReadLine();
        }

        public void ShowText(string text)
        {
            Console.WriteLine(text);
        }
    }
}
