using CreatingAnExtensionMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePowerOfIEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> developers = GenerateData.GoDevelopers();
            IEnumerable<Employee> sales = GenerateData.GoSales();

            ("Developers: " + developers.MyCount().ToString()).Out();
            String.Empty.Out();

            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Name.Out();
            }
            String.Empty.Out();

            ("Sales: " + sales.MyCount().ToString()).Out();
            String.Empty.Out();

            foreach (var x in sales)
            {
                x.Out();
            }
            String.Empty.Out();

            "Press any key to continue".Out();
            Console.ReadKey();
        }
    }
}
