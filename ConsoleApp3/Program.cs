using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Airport londonAirport = Airport.CreateAirport("London");
            Airport parisAirport = Airport.CreateAirport("Paris");
            Airport stockholmAirport = Airport.CreateAirport("Stockholm");
            Airport pyongyangAirport = Airport.CreateAirport("Pyongyang");

            Passenger passenger = new Passenger
            {
                FirstName = "Steven",
                LastName = "Daniel",
                Source = parisAirport,
                Destination = pyongyangAirport
            };

            passenger.BookFlight("Arik", new DateTime(2019, 7, 8), "First Class");

            Console.WriteLine($"{passenger.FirstName} is at {passenger.Location}");

            passenger.BoardFlight();

            Console.WriteLine($"{passenger.FirstName} is at {passenger.Location}");

            Console.WriteLine("\n =========================== \n");

            Passenger passenger1 = new Passenger()
            {
                FirstName = "Larry",
                LastName = "Page",
                Source = pyongyangAirport,
                Destination = stockholmAirport
            };

            passenger1.BookFlight("Aero Contractors", new DateTime(2019, 7, 10), "First Class");

            Console.WriteLine($"{passenger1.FirstName} is at {passenger1.Location}");

            passenger1.BoardFlight();

            Console.WriteLine($"{passenger1.FirstName} is at {passenger1.Location}");

            Console.WriteLine("\n =========================== \n");


            Passenger passenger2 = new Passenger()
            {
                FirstName = "Sergey",
                LastName = "Brin",
                Source = pyongyangAirport,
                Destination = stockholmAirport
            };

            passenger2.BookFlight("Aero Contractors", new DateTime(2019, 7, 10), "Economy");

            Console.WriteLine($"{passenger2.FirstName} is at {passenger2.Location}");

            passenger2.BoardFlight();

            Console.WriteLine($"{passenger2.FirstName} is at {passenger2.Location}");

            Console.ReadKey();
        }
    }

  
}
