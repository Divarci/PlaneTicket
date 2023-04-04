using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DALayer;
using EntityLayer;

namespace DALayer
{
    public class DALFlights
    {

        public static void CatchFlightNumber(ComboBox from, ComboBox to, DateTimePicker deptime, List<int> values)
        {
            // find totalflightnumber

            SqlCommand cmd2 = new SqlCommand("Select * from Tbl_Lines where lineFrom=@p1 and lineTo=@p2 and lineDate=@p3", Connection.conn);
            cmd2.Parameters.AddWithValue("@p1", from.Text);
            cmd2.Parameters.AddWithValue("@p2", to.Text);
            cmd2.Parameters.AddWithValue("@p3", deptime.Text);


            if (cmd2.Connection.State != ConnectionState.Open)
            {
                cmd2.Connection.Open();
            }
            SqlDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                from.Text = dr2[1].ToString();
                to.Text = dr2[2].ToString();
                deptime.Text = dr2[3].ToString();

                values.Add(Convert.ToInt32(dr2[4]));
                values.Add(Convert.ToInt32(dr2[0]));

            }
            Connection.conn.Close();
        }
        public static void CatchFlightInfos(List<string> hours, List<string> prices, List<string> flightNo, List<string> CaptainName, List<string> FlightId, int lineId)
        {


            SqlCommand cmd = new SqlCommand("Select flightTime,flightPrice,flightNo,CaptainName,flightId from Tbl_Flights where flightLine=@p1", Connection.conn);
            cmd.Parameters.AddWithValue("@p1", lineId);

            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                hours.Add(dr[0].ToString());
                prices.Add(dr[1].ToString());
                flightNo.Add(dr[2].ToString());
                CaptainName.Add(dr[3].ToString());
                FlightId.Add(dr[4].ToString());
            }
            Connection.conn.Close();
            
        }
    }
}