using System;
using System.Collections.Generic;
using System.Text;

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
