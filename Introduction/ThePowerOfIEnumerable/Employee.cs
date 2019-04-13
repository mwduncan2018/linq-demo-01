using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePowerOfIEnumerable
{
    public class Employee : IComparable<Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CompareTo(Employee other)
        {
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return Name + " (" + Id + ")";
        }

    }
}
