using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IPresenter
    {
        void ShowText(string text);
        string FetchInput();
    }
}
