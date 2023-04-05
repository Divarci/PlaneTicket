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
    public class LLSeats
    {
        public static bool LLSeatUpdate(EntitySeats seats,string FNO,string seatno)
        {
            
            return DALSeats.DALSeatUpdate(seats, FNO, seatno);


        }

        public static void ReservedSeats(string FID, List<string> values)
        {
            DALSeats.DALReservedSeats(FID, values);

        }
        public static List<string> LLSeatInforation(string FID)
        {
            return DALSeats.DALSeatInformaion(FID);
        }
    }
}
