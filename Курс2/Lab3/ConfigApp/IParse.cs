using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigApp
{
    interface IParse
    {
        T Parse<T>(string path) where T : new();
    }
}
