using System;
using System.Collections.Generic;
using ConsoleApp3.FlightConcerns;

namespace ConsoleApp3.AirlineConcerns
{
    public abstract class Airline : ITicket
    {
        public string AirlineName { get; set; }
        public List<Flight> AvailableFlights { get; set; } = new List<Flight>();
        public Dictionary<string, int> AirlineClasses { get; set; } = new Dictionary<string, int>();

        public abstract int sellTicket();
        public abstract void setUpFlights();
        public abstract Flight checkFlightAvailability(string destination, DateTime flightTime);
        public abstract int generateTicketId();
        public abstract void RegisterAFlight(Flight flight);

    }
}
