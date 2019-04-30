using NUnit.Framework;
using ConsoleApp3.AirlineConcerns;
using ConsoleApp3.FlightConcerns;
using System;
using System.Linq;

namespace ConsoleApp3.Test
{
    [TestFixture]
    public class AirportTest
    {
        private static Random random = new Random();

        [Test]
        public void Creating_An_Airline()
        {
            Airline anAirline = AirlineFactory.CreateAirline("passenger", "Arik");

            Assert.IsInstanceOf(typeof(PassengerAirline), anAirline);

            StringAssert.AreEqualIgnoringCase(anAirline.AirlineName, "Arik");

            Assert.IsInstanceOf(typeof(Airline), anAirline);
        }

        [Test]
        public void Registering_An_Airline()
        {
            Airport anAirport = Airport.CreateAirport("Lagos");
            Airline anAirline = AirlineFactory.CreateAirline("passenger", "Arik");

            anAirport.RegisterAirline(anAirline);

            CollectionAssert.Contains(anAirport.AvailableAirlines, anAirline);
        }

        [Test]
        public void Getting_All_Airlines_Within_The_Airport()
        {
            Airport anAirport = Airport.CreateAirport("Lagos");
            Airline anAirline = AirlineFactory.CreateAirline("passenger", "Arik");

            anAirport.RegisterAirline(anAirline);

            CollectionAssert.AllItemsAreInstancesOfType(anAirport.AvailableAirlines, typeof(Airline));
        }

        [TestCase(2), MaxTime(50)]
        [TestCase(1000)]
        [TestCase(7)]
        public void Booking_A_Full_Flight(int capacity)
        {
            Airport sourceAirport = Airport.CreateAirport("Lagos");
            Airport destinationAirport = Airport.CreateAirport("Berlin");

            Airline theAirline = AirlineFactory.CreateAirline("passenger", "Emirates");
            sourceAirport.RegisterAirline(theAirline);

            DateTime flightTime = new DateTime(2019, 7, 8);

            Flight flight = new Flight()
            {
                Destination = "Berlin",
                FlightCapacity = capacity,
                FlightTime = flightTime
            };

            theAirline.RegisterAFlight(flight);

            string[] passengerNames = { "Daniel", "Zuckerberg", "Bezos", "Page", "Gates" };

            for(int i = 0; i < capacity; i++)
            {
                Passenger passenger = new Passenger()
                {
                    FirstName = RandomString(8),
                    Source = sourceAirport,
                    Destination = destinationAirport,
                };

                passenger.BookFlight("Emirates", flightTime, "Economy");
            }

            Passenger latePassenger = new Passenger()
            {
                FirstName = "Gates",
                Source = sourceAirport,
                Destination = destinationAirport,
            };

            string expectedResponse = $"Sorry {latePassenger.FirstName}, There are no more seats on the flight going to {latePassenger.Destination.Location}";

            string actualResponse = latePassenger.BookFlight("Emirates", flightTime, "Economy");

            StringAssert.AreEqualIgnoringCase(expectedResponse, actualResponse);
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
