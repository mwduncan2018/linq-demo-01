using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsFuelEfficiency
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("CarInfo.txt");

            var query = cars.OrderByDescending(x => x.Combined);

            foreach (var car in query.Take(10))
            {
                Console.WriteLine(car.Name + " --- " + car.Highway);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static List<Car> ProcessFile(string path)
        {
            return File.ReadAllLines(path)
                                .Where(x => x.Length > 1)
                                .Skip(1)
                                .Select(Car.ParseFromCsvLine)
                                .ToList();

        }

    }
}
