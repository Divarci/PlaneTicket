using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    //properties for lines tabele
    public class EntityLines
    {
        private string From;
        private string To;
        private byte flightNumber;

        public string From1 { get => From; set => From = value; }
        public string To1 { get => To; set => To = value; }
        public byte FlightNumber { get => flightNumber; set => flightNumber = value; }
    }
}
