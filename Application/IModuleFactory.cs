using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IModuleFactory
    {
        IModule BuildModule(string opt);
    }
}
