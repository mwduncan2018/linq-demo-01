using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingAnExtensionMethod
{
    public static class MyStringExtensions
    {
        static public string Out(this object str)
        {
            Console.WriteLine(str.ToString());
            return str.ToString();
        }

    }
}
