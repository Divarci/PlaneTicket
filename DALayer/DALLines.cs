using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EntityLayer;
using System.Data;
using System.Windows.Forms;

namespace DALayer
{
    public class DALLines
    {
        public static List<string> LineFromList()
        {
            List<string> values = new List<string>();
            SqlCommand cmd = new SqlCommand(" Select DISTINCT (lineFrom) FROM Tbl_Lines", Connection.conn);
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
              
                
                values.Add(dr["lineFrom"].ToString());
                

                
            }
            dr.Close();
            return values;
        }


        public static List<string> LineToList(ComboBox cmb1, ComboBox cmb2)
        {
            List<string> values = new List<string>();
            SqlCommand cmd = new SqlCommand("Select lineTo from Tbl_Lines where lineFrom=@p1", Connection.conn);

            cmd.Parameters.AddWithValue("@p1", cmb1.Text);
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                values.Add(dr[0].ToString());
            }
            cmb2.DataSource = values;
               

            Connection.conn.Close();
            return values;
        }
    }
}
