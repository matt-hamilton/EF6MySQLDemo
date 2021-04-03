using System;
using System.Collections.Generic;
using System.Linq;

namespace EF6MySQLDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ModelContext())
            {
                var count = context.Cars.Count();
                Console.WriteLine($"{count} car(s) found");
                if (count == 0)
                {
                    Console.WriteLine("Do you want to add some cars (y/n)");

                    var key = Console.ReadLine().ToLower();

                    if (key == "y")
                    {
                        List<Car> cars = new List<Car>();

                        cars.Add(new Car { Manufacturer = "Nissan", Model = "Pathfinder", Year = 2008 });
                        cars.Add(new Car { Manufacturer = "Honda", Model = "Civic", Year = 2013 });
                        cars.Add(new Car { Manufacturer = "Volkswagen", Model = "Golf", Year = 2012 });

                        context.Cars.AddRange(cars);
                        context.SaveChanges();

                        Console.WriteLine("3 cars were added");

                        PrintCars(context);
                    }
                }
                else
                {
                    PrintCars(context);
                }

            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void PrintCars(ModelContext context)
        {
            foreach (var car in context.Cars)
            {
                Console.WriteLine($"{car.Year} {car.Manufacturer} {car.Model}");
            }
        }
    }
}
