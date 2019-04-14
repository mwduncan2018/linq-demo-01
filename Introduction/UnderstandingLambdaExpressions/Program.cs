using CreatingAnExtensionMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePowerOfIEnumerable;

namespace UnderstandingLambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            FuncAndActionPractice();
            var sales = GenerateData.GoSales();

            "Query Syntax:".Out();
            var query = from sale in sales
                        where sale.Name.Length > 5
                        orderby sale.Name descending
                        select sale.Name;
            foreach (var item in query) { item.Out(); }
            String.Empty.Out();


            "Method Syntax:".Out();
            foreach (var item in sales
                .Where(x => x.Name.StartsWith("A"))
                .OrderByDescending(y => y.Name))
            {
                item.Out();
            }

            "Press any key to continue".Out();
            Console.ReadKey();
        }

        static void FuncAndActionPractice()
        {
            Func<int, int> MySquare = x => x * x;
            Func<int, int, int> MyAdd = (int x, int y) => x + y;
            Func<int, int, int> MySubtract = (x, y) => { return x - y; };

            MyAdd(8, 2).Out();
            MySquare(2).Out();
            MySubtract(7, 2).Out();
            String.Empty.Out();

            Action<int> PrintInt = x => x.Out();
            Action<string> PrintString = x => x.Out();

            PrintInt(3);
            PrintString("Diet Coke");

            "=================================================================".Out();
            String.Empty.Out();
        }

    }
}
