using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityFlight
    {
        private int flightLine;
        private string flightDate;
        private string flightTime;

        public int FlightLine { get => flightLine; set => flightLine = value; }
        public string FlightDate { get => flightDate; set => flightDate = value; }
        public string FlightTime { get => flightTime; set => flightTime = value; }
    } 
}
