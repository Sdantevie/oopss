using ConsoleApp3.FlightConcerns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3.AirlineConcerns
{
    class CargoAirline : Airline
    {
        public CargoAirline(string airlineName)
        {
            AirlineName = airlineName;
        }

        public override Flight checkFlightAvailability(string destination, DateTime flightTime)
        {
            List<Flight> availableFlight = AvailableFlights.FindAll(x => (x.Destination == destination) && (x.FlightTime == flightTime));
            return availableFlight.Count > 0 ? availableFlight.First() : null;
        }

        public override int generateTicketId()
        {
            Random random = new Random();
            return random.Next(1000, 10000);
        }

        public override void RegisterAFlight(Flight flight)
        {
            AvailableFlights.Add(flight);
        }

        public override int sellTicket()
        {
            return generateTicketId();
        }

     
        public override void setUpFlights()
        {

            Flight flight = new Flight();
            flight.Destination = "London";
            flight.FlightTime = new DateTime(2019, 7, 8);
            flight.FlightCapacity = 10;
            flight.FlightType = "Cargo";
            flight.FlightPrice = 400;
            AvailableFlights.Add(flight);

            Flight flight1 = new Flight();
            flight1.Destination = "Paris";
            flight1.FlightTime = new DateTime(2019, 7, 9);
            flight.FlightCapacity = 20;
            flight.FlightType = "Cargo";
            flight.FlightPrice = 400;
            AvailableFlights.Add(flight1);

            Flight flight2 = new Flight();
            flight.Destination = "Pyongyang";
            flight2.FlightTime = new DateTime(2019, 7, 10);
            flight2.FlightCapacity = 100;
            flight.FlightType = "Cargo";
            flight2.FlightPrice = 200;

        }

    }
}
