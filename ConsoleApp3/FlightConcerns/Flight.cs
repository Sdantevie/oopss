using System;
using System.Collections.Generic;

namespace ConsoleApp3.FlightConcerns
{
    public class Flight
    {
        public string Destination { get; set; }
        public DateTime FlightTime { get; set; }
        public int FlightPrice { get; set; }
        public int FlightCapacity { get; set; }
        public string FlightType { get; set; }
        public List<Passenger> FlightManifest { get; set; } = new List<Passenger>();
    }
}
