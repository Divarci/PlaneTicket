using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DALayer;
using System.Windows.Forms;

namespace LogicLayer
{
    public class LLFlights
    {
        //makes selection line id and flight number
        public static void LLCatchFlightNumber(string From, string To, string DepTime, List<int> values)
        {
            DALFlights.CatchFlightNumber(From, To, DepTime, values);
        }
        //keeps informations for selected flight
        public static void LLCatchFlightInfos(List<string> hours, List<string> prices, List<string> flightNo, List<string> CaptainName,List<string> FlightId, int lineId)
        {
            DALFlights.CatchFlightInfos(hours, prices, flightNo, CaptainName, FlightId, lineId);
        }
    }
}