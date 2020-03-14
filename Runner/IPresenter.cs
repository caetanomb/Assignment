using System;
using System.Collections.Generic;
using System.Text;

namespace Runner
{
    public interface IPresenter
    {
        void ShowText(string text);
        string FetchInput();
    }
}
