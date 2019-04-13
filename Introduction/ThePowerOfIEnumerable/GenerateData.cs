using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePowerOfIEnumerable
{
    public static class GenerateData
    {
        public static SortedSet<Employee> GoDevelopers()
        {
            SortedSet<Employee> developers = new SortedSet<Employee>
            {
                new Employee { Id = 11, Name = "Mike" },
                new Employee { Id = 22, Name = "Trav" },
                new Employee { Id = 33, Name = "Stephanie" },
                new Employee { Id = 44, Name = "Amber" }
            };
            return developers;
        }

        public static SortedSet<Employee> GoSales()
        {
            SortedSet<Employee> sales = new SortedSet<Employee>
            {
                new Employee { Id = 3, Name = "Bill" },
                new Employee { Id = 4, Name = "Jack" },
                new Employee { Id = 5, Name = "Gail" },
                new Employee { Id = 6, Name = "Sandra" },
                new Employee { Id = 11, Name = "Mike" },
                new Employee { Id = 22, Name = "Trav" },
                new Employee { Id = 33, Name = "Stephanie" },
                new Employee { Id = 44, Name = "Angela" },
                new Employee { Id = 55, Name = "Arnold" },
                new Employee { Id = 66, Name = "Aeris" },
                new Employee { Id = 77, Name = "John" },
                new Employee { Id = 88, Name = "Amber" }

            };
            return sales;
        }
    }
}
