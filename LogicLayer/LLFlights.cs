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
        public static void LLCatchFlightNumber(ComboBox From, ComboBox To, DateTimePicker DepTime, List<int> values)
        {
            DALFlights.CatchFlightNumber(From, To, DepTime, values);
        }

        public static void LLCatchFlightInfos(List<string> hours, List<string> prices, List<string> flightNo, List<string> CaptainName,List<string> FlightId, int lineId)
        {
            DALFlights.CatchFlightInfos(hours, prices, flightNo, CaptainName, FlightId, lineId);
        }
    }
}