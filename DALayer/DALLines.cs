using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data;
using System.Windows.Forms;

namespace DALayer
{
    public class DALLines
    {
        //sql command for filling combobox depatures
        public static List<string> LineFromList()
        {
            //create a list
            List<string> values = new List<string>();
            //query
            SqlCommand cmd = new SqlCommand(" Select DISTINCT (lineFrom) FROM Tbl_Lines", Connection.conn);
            //check connection status
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            //add datas to the list
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
              
                
                values.Add(dr["lineFrom"].ToString());
                

                
            }
            dr.Close();
            return values;
        }

        //sql command for filling combobox destination

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
