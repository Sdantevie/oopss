using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp3.AirlineConcerns;
using ConsoleApp3.FlightConcerns;

namespace ConsoleApp3
{
    public class PassengerAirline : Airline
    {
        public PassengerAirline(string airlineName, Dictionary<string, int> airlineClasses)
        {
            AirlineName = airlineName;
            AirlineClasses = airlineClasses;
        }

        Random random = new Random();

        public PassengerAirline(string airlineName)
        {
            AirlineName = airlineName;
            AirlineClasses = new Dictionary<string, int>()
            {
                {"Economy", 1 }
            };
        }

        public override void setUpFlights()
        {
            
            Flight flight = new Flight();
            flight.Destination = "London";
            flight.FlightTime = new DateTime(2019, 7, 8);
            flight.FlightCapacity = 10;
            flight.FlightType = "Passenger";
            flight.FlightPrice = 400;
            AvailableFlights.Add(flight);

            Flight flight1 = new Flight();
            flight1.Destination = "Paris";
            flight1.FlightTime = new DateTime(2019, 7, 9);
            flight1.FlightCapacity = 20;
            flight1.FlightType = "Passenger";
            flight1.FlightPrice = 500;
            AvailableFlights.Add(flight1);

            Flight flight2 = new Flight();
            flight2.Destination = "Stockholm";
            flight2.FlightTime = new DateTime(2019, 7, 10);
            flight2.FlightCapacity = 2;
            flight2.FlightType = "Passenger";
            flight2.FlightPrice = 200;
            AvailableFlights.Add(flight2);

            Flight flight3 = new Flight();
            flight3.Destination = "Pyongyang";
            flight3.FlightTime = new DateTime(2019, 7, 10);
            flight3.FlightCapacity = 100;
            flight3.FlightType = "Passenger";
            flight3.FlightPrice = 700;
            AvailableFlights.Add(flight3);
        }

        public override int sellTicket()
        {
            int ticketId = generateTicketId();
            return ticketId;
        }

        public override Flight checkFlightAvailability(string destination, DateTime flightTime)
        {
            List<Flight> availableFlight  = AvailableFlights.FindAll(x => x.Destination == destination);
            return availableFlight.Count > 0 ? availableFlight.First() : null;
        }

        public override int generateTicketId()
        {
            return random.Next(100, 1000);
        }

        public override void RegisterAFlight(Flight flight)
        {
            AvailableFlights.Add(flight);
        }
    }
}
