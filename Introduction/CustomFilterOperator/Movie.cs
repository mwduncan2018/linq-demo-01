using CreatingAnExtensionMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomFilterOperator
{
    public class Movie : IComparable<Movie>
    {
        public string Title { get; set; }
        public float Rating { get; set; }

        private int _year;
        public int Year {
            get
            {
                ("Returning " + _year + " for " + Title).Out();
                return _year;
            }
            set
            {
                _year = value;
            }
        }

        public int CompareTo(Movie movie)
        {
            return Title.CompareTo(movie.Title);
        }

        public override string ToString()
        {
            return Title + " (" + Year + ", " + Rating + ")";
        }
    }
}
