using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FuelEfficiency
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> carList = ProcessCarFile("car_info.txt");
            List<Manufacturer> manList = ProcessManufacturerFile("car_info_02.txt");



            
            if (false)
            {
                RunJoinDemo_01(carList, manList);
                RunDemoPartOne(carList);
                RunMyForEachDemo(carList);
                RunSelectDemo(carList);
                RunSelectManyDemo(carList);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void RunJoinDemo_01(IEnumerable<Car> carList, IEnumerable<Manufacturer> manList)
        {
            Console.WriteLine("----------------------------------------------------------------------");
            var querySyntax = from y in carList
                              join x in manList on y.Manufacturer equals x.Name
                              orderby y.Combined descending, y.Name ascending
                              select new
                              {
                                  x.Headquarters,
                                  y.Name,
                                  y.Combined
                              };
            querySyntax.Take(5).MyForEach(x => Console.WriteLine(x.Headquarters + " -- " + x.Name + " -- " + x.Combined)).ToList();
            Console.WriteLine("----------------------------------------------------------------------");

            var methodSyntax =
                carList.Join(manList,
                                car => car.Manufacturer,
                                man => man.Name,
                                (car, man) => new
                                {
                                    man.Headquarters,
                                    car.Name,
                                    car.Combined
                                })
                    .OrderByDescending(x => x.Combined)
                    .ThenBy(x => x.Name);
            methodSyntax.Take(5).MyForEach(x => Console.WriteLine(x.Headquarters + " -- " + x.Name + " -- " + x.Combined)).ToList();
            Console.WriteLine("----------------------------------------------------------------------");
        }

        private static void RunSelectManyDemo(IEnumerable<Car> carList)
        {
            Console.WriteLine("----------------------------------------------------------------------");
            var result = carList
                .SelectMany(x => x.Name)
                .OrderByDescending(x => x)
                .MyForEach(x => Console.WriteLine(x))
                .Take(5)
                .ToList();
            Console.WriteLine("----------------------------------------------------------------------");
        }

        private static List<Car> ProcessCarFile(string path)
        {
            var query = File.ReadAllLines(path)
                                .Where(x => x.Length > 1)
                                .Skip(1)
                                .ToCar();
            return query.ToList();
        }

        private static List<Manufacturer> ProcessManufacturerFile(string path)
        {
            var query = File.ReadAllLines(path)
                .Where(x => x.Length > 1)
                .Select(Manufacturer.ParseFromCsvLine)
                .ToList();
            return query;
        }

        private static void RunSelectDemo(List<Car> carList)
        {
            carList
                .Where(x => x.Combined > 40)
                .OrderByDescending(x => x.Combined)
                .Take(5)
                .Select(x => new
                {
                    x.Name,
                    x.Manufacturer,
                    x.Combined
                })
                .MyForEach(x =>
                {
                    Console.WriteLine(x.Name + " -- " + x.Manufacturer + " -- " + x.Combined);
                })
                .ToList();
        }

        private static void RunDemoPartOne(List<Car> carList)
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Car topBmwMileage2016 = carList
                .OrderBy(x => x.Combined)
                .FirstOrDefault(x => x.Year == 2016 && x.Manufacturer == "BMW");
            Console.WriteLine(topBmwMileage2016.Name);
            Console.WriteLine("----------------------------------------------------------------------");

            if (carList.Any())
            {
                Console.WriteLine("carList has values");
                if (carList.Any(x => x.Manufacturer == "Ford"))
                {
                    Console.WriteLine("carList has 'Ford'");
                }
                if (!carList.All(x => x.Manufacturer == "Ford"))
                {
                    Console.WriteLine("not all carList is 'Ford'");
                }
            }
            else
            {
                Console.WriteLine("carList does not have values");
            }

        }
        private static void RunMyForEachDemo(List<Car> carList)
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("MY FOR EACH...");
            carList.MyForEach(x => Console.WriteLine(x.Name)).Take(2).ToList();
            Console.WriteLine("----------------------------------------------------------------------");
        }
    }

    public static class MyLinqForEach
    {
        public static IEnumerable<T> MyForEach<T>(
            this IEnumerable<T> items,
            Action<T> processingFunction)
        {
            foreach (var item in items)
            {
                processingFunction(item);
                yield return item;
            }

        }

    }
}