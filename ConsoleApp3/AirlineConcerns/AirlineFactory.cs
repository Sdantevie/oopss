using System.Collections.Generic;

namespace ConsoleApp3.AirlineConcerns
{
    public class AirlineFactory
    {
        public static Airline CreateAirline(string airLineType, string airlineName)    
        {
            switch (airLineType)
            {
                case "passenger" :
                    return new PassengerAirline(airlineName);
                case "cargo": 
                    return new CargoAirline(airlineName);
                default: return null;
            }
        }

        public static Airline CreateAirline(string airLineType, string airlineName, Dictionary<string, int> airlineClasses)
        {
            switch (airLineType)
            {
                case "passenger":
                    return new PassengerAirline(airlineName, airlineClasses);
                case "cargo":
                    return new CargoAirline(airlineName);
                default: return null;
            }
        }

    }
}
