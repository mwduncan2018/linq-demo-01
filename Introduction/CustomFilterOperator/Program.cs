using CreatingAnExtensionMethod;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomFilterOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Movie> movies = new List<Movie>
            {
                new Movie { Title = "The Dark Knight", Rating = 8.9f, Year = 2008 },
                new Movie { Title = "The King's Speech", Rating = 8.0f, Year = 2010 },
                new Movie { Title = "Casablanca", Rating = 8.5f, Year = 1942 },
                new Movie { Title = "Star Wars V", Rating = 8.7f, Year = 1980 },
                new Movie { Title = "Some Kind Of Monster", Rating = 6.7f, Year = 2003 }
            };

            IEnumerable<Movie> query = movies.MyFilter(x => x.Year >= 2000);

            IEnumerable<Movie> query2 = movies
                .Where(x => x.Year >= 2000)
                .OrderByDescending(y => y.Rating);

            IEnumerator<Movie> enumerator = query.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Title.Out();
            }

            "==============================================================================".Out();
            IEnumerable<int> query3 = MyLinq.CalculatingInfinity().Take(100).TakeWhile(x => x < 100);
            foreach (var number in query3)
            {
                number.Out();
            }

            String.Empty.Out();
            "Press any key to exit...".Out();


            Console.ReadKey();
        }
    }
}
