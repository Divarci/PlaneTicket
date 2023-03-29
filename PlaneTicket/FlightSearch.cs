using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using DALayer;
using LogicLayer;
using System.Data.SqlClient;

namespace PlaneTicket
{
    public partial class FlightSearch : Form
    {
        public FlightSearch()
        {
            InitializeComponent();
        }

        
        private void FlightSearch_Load(object sender, EventArgs e)
        {


            cmbFrom.DataSource = LLLines.LLLineFromList();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            LLLines.LLLineToList(cmbFrom, cmbTo);

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label6.Text = dtpDep.Text;
        }

        private void btnFindCheapFlight_Click(object sender, EventArgs e)
        {
            frmFlights fr = new frmFlights();
            fr.Show();

            // find totalflightnumber
            int flightNumber = 0;
            int lineId = 0;
            SqlCommand cmd2 = new SqlCommand("Select * from Tbl_Lines where lineFrom=@p1 and lineTo=@p2 and lineDate=@p3", Connection.conn);
            cmd2.Parameters.AddWithValue("@p1", cmbFrom.Text);
            cmd2.Parameters.AddWithValue("@p2", cmbTo.Text);
            cmd2.Parameters.AddWithValue("@p3", dtpDep.Text);
            if (cmd2.Connection.State != ConnectionState.Open)
            {
                cmd2.Connection.Open();
            }
            SqlDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                cmbFrom.Text = dr2[1].ToString();
                cmbTo.Text = dr2[2].ToString();
                dtpDep.Text = dr2[3].ToString();

                flightNumber = Convert.ToInt16(dr2[4].ToString());
                lineId = Convert.ToInt16(dr2[0].ToString());
                
            }
            Connection.conn.Close();

            // added flight hours in a temp list
            List<string> hours = new List<string>();
            SqlCommand cmd = new SqlCommand("Select flightTime from Tbl_Flights where flightLine=@p1", Connection.conn);
            cmd.Parameters.AddWithValue("@p1", lineId);

            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                hours.Add(dr[0].ToString());
            }
            Connection.conn.Close();


            // add buttons
            int top = 40;
            int left = 40;
            int width = 100;
            for (int i = 0; i < flightNumber; i++)
            {
                Button newbutton = new Button();

                newbutton.Top = top;
                newbutton.Left = left;
                newbutton.Width = width;
                newbutton.Text = hours[i];
                newbutton.Name = "btn" + i;
                fr.Controls.Add(newbutton);

                top += 40;

                

            }

            
        }
    }
}
