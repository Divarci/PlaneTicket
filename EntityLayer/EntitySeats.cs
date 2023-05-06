using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    //seat table props
    public class EntitySeats
    {
        private string pessengerName;
        private string pessengerSurname;
        private string passportNuber;

        public string PessengerName { get => pessengerName; set => pessengerName = value; }
        public string PessengerSurname { get => pessengerSurname; set => pessengerSurname = value; }
        public string PassportNuber { get => passportNuber; set => passportNuber = value; }
    }
}
