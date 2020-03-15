using Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests
{
    public class TestPresenter : IPresenter
    {
        public TestPresenter()
        {

        }
        public TestPresenter(string inputText)
        {
            FetchedInput = inputText;
        }
        public string FetchedInput { get; set; }
        public string ShowedText { get; set; }

        public string FetchInput()
        {
            return FetchedInput;
        }

        public void ShowText(string text)
        {
            ShowedText = text;
        }
    }
}
