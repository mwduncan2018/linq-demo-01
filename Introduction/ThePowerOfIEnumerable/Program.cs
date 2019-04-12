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
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee { Id = 1, Name = "Mike" },
                new Employee { Id = 2, Name = "Trav" }
            };
            IEnumerable<Employee> sales = new List<Employee>
            {
                new Employee { Id = 3, Name = "Bill" },
                new Employee { Id = 4, Name = "Jack" },
                new Employee { Id = 5, Name = "Gail" },
                new Employee { Id = 6, Name = "Sandra" }
            };
            HashSet<Employee> employees = new HashSet<Employee>();
            

            ("Developers: " + developers.MyCount().ToString()).Out();
            ("Sales: " + sales.MyCount().ToString()).Out();
            String.Empty.Out();
            
            

            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Name.Out();
            }
            String.Empty.Out();

            "Press any key to continue".Out();
            Console.ReadKey();
        }
    }
}
