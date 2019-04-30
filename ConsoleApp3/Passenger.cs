using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp3.AirlineConcerns;
using ConsoleApp3.FlightConcerns;


namespace ConsoleApp3
{
    public class Passenger
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Airport Destination { get; set; }
        public Airport Source { get; set; }
        public bool BoughtTicket { get; set; }
        public string Location { get; set; }
        public int TicketId { get; set; }
        public int HasCargo { get; set; }

        public List<Flight> bookedFlights { get; set; } = new List<Flight>();

        public string BookFlight(string airline, DateTime flightTime, string airlineClass)
        {
            Location = Source.Location;
            string responseString;

            List<Airline> choosenAirlineList = Source.AvailableAirlines.FindAll(x => x.AirlineName == airline);
            if(choosenAirlineList.Count > 0)
            {
                Airline choosenAirline = choosenAirlineList.First();

                Flight flightAvailable = choosenAirline.checkFlightAvailability(Destination.Location, flightTime);

                if (flightAvailable != null)
                {
                    if(flightAvailable.FlightManifest.Count < flightAvailable.FlightCapacity)
                    {
                        int price = flightAvailable.FlightPrice * choosenAirline.AirlineClasses[airlineClass];
                        int ticketId = choosenAirline.sellTicket();
                        BoughtTicket = true;
                        flightAvailable.FlightManifest.Add(this);
                        bookedFlights.Add(flightAvailable);
                        responseString = $"{FirstName} has bought {airline}'s ticket with ID Number {ticketId} for flight going to {Destination.Location}. Price ${price}.00 ({airlineClass})";
                        Console.WriteLine(responseString);
                    } else
                    {
                        responseString = $"Sorry {FirstName}, There are no more seats on the flight going to {Destination.Location}";
                        Console.WriteLine(responseString);
                    }
                }
                else
                {
                    responseString = $"Sorry {FirstName}, There are no flights going to {Destination.Location} at your proposed time";
                    Console.WriteLine(responseString);
                }

            } else
            {
                responseString = $"Sorry {FirstName}, that airline is not available";
                Console.WriteLine(responseString);
            }

            return responseString;
        }

        public void GetDestination()
        {
            Console.WriteLine($"{FirstName} {LastName} is going to {Destination.Location}");
        }

        public bool BoardFlight()
        {
            if (BoughtTicket)
            {
                Console.WriteLine($"{FirstName} has boarded");
                Location = Destination.Location;
            } else
            {
                Console.WriteLine($"{FirstName} has not bought ticket, therefore no boarding");
            }

            return BoughtTicket;
        }

        public List<Flight> getBookedFlights()
        {
            return bookedFlights.Count > 0 ? bookedFlights : null;
        }

        public void CancelFlight(int flightId)
        {
            bookedFlights.RemoveAt(flightId);
        }
    }
}
