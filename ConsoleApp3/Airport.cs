using ConsoleApp3.AirlineConcerns;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class Airport
    {
        public List<Airline> AvailableAirlines = new List<Airline>();
        public List<string> Departures { get; set; } = new List<string>();
        public List<string> Arrivals { get; set; } = new List<string>();
        public string Location { get; set; }
       
        public void SetUpAirport()
        {
            Dictionary<string, int> arikAirlineClasses = new Dictionary<string, int>()
            {
                { "Economy", 1 },
                { "Business", 5 },
                { "First Class", 10 }
            };

            Airline airline1 = AirlineFactory.CreateAirline("passenger", "Arik", arikAirlineClasses);
            airline1.setUpFlights();
            AvailableAirlines.Add(airline1);

            Dictionary<string, int> aeroAirlineClasses = new Dictionary<string, int>()
            {
                { "Economy", 1 },
                { "Premium Economy", 3 },
                { "Business", 5 },
                { "First Class", 7 }
            };

            Airline airline2 = AirlineFactory.CreateAirline("passenger", "Aero Contractors", aeroAirlineClasses);
            airline2.setUpFlights();
            AvailableAirlines.Add(airline2);

            Airline airline3 = AirlineFactory.CreateAirline("cargo", "Arik");
            airline3.setUpFlights();
            AvailableAirlines.Add(airline3);
        }

        public void RegisterAirline(Airline airline)
        {
            AvailableAirlines.Add(airline);
        }


        public static Airport CreateAirport(string location)
        {
            Airport airport = new Airport();
            airport.SetUpAirport();
            airport.Location = location;
            return airport;
        }
    }
}
