using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomFilterOperator
{
    public static class MyLinq
    {
        public static IEnumerable<int> CalculatingInfinity()
        {
            int x = 1;
            int y = 0;
            int z;
            while (true)
            {
                z = x + y;
                yield return z;
                y = x;
                x = z;
            }
        }

        public static IEnumerable<T> MyFilter<T>(
            this IEnumerable<T> source, 
            Func<T, bool> processingFunction)
        {
            foreach (var item in source)
            {
                if (processingFunction(item) == true)
                {
                    yield return item;
                }
            }
        }
    }
}
