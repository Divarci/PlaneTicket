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
        public static List<int> LLCatchFlightNumber(ComboBox From, ComboBox To, DateTimePicker DepTime, List<int> values)
        {
            return DALFlights.CatchFlightNumber(From, To, DepTime, values);
        }

        public static List<string> LLCatchFlightInfos(List<string> hours, List<string> prices, List<string> flightNo, List<string> CaptainName, int lineId)
        {
            return DALFlights.CatchFlightInfos(hours,prices, flightNo, CaptainName, lineId);
        }
    }
}