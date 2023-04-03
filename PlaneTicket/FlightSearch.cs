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
using System.Windows.Markup;

namespace PlaneTicket
{
    public partial class FlightSearch : Form
    {
        public FlightSearch()
        {
            InitializeComponent();
        }
        List<string> hours = new List<string>();
        List<string> prices = new List<string>();
        List<string> flightNo = new List<string>();
        List<string> CaptainName = new List<string>();
       
        void button_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            frmSeatPlan fr = new frmSeatPlan();
            for (int i = 0; i < hours.Count; i++)
            {
                if (btn.Text == hours[i])
                {
                    fr.Text = hours[i] + "    " + flightNo[i] +"    Seat Plan";
                    fr.tempHours = hours[i];
                    fr.tempPrices = prices[i];
                    fr.tempFno = flightNo[i];
                    fr.tempCaptain= CaptainName[i];
                    fr.tempGuestNo = Convert.ToInt16(numericUpDown1.Value);

                }
            }
            fr.Show();
           
            
        }
        /*
        void button_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Green;
        }
        */
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
            hours.Clear();
            prices.Clear();
            flightNo.Clear();
            CaptainName.Clear();
            frmFlights fr = new frmFlights();
            
            fr.Show();
            /*
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
            */
            List<int> values = new List<int>();
            LLFlights.LLCatchFlightNumber(cmbFrom, cmbTo, dtpDep, values);
            int lineId = values[1];
            int flightNumber = values[0];

            // added flight hours in a temp list
            
            LLFlights.LLCatchFlightInfos(hours, prices, flightNo, CaptainName, lineId);
            /*
            List<string> hours = new List<string>();
            List<string> prices = new List<string>();
            List<string> flightNo = new List<string>();
            List<string> CaptainName = new List<string>();
            SqlCommand cmd = new SqlCommand("Select flightTime,flightPrice,flightNo,CaptainName from Tbl_Flights where flightLine=@p1", Connection.conn);
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
            }
            Connection.conn.Close();
            */

            // add buttons
            int l1 = 20;
            int l2 = 20;

            for (int i = 0; i < flightNumber; i++)
            {
                //create button
                Button newbutton = new Button();

                newbutton.FlatStyle = FlatStyle.Flat;
                newbutton.FlatAppearance.BorderColor = Color.LightSeaGreen;
                newbutton.FlatAppearance.BorderSize = 3;
                newbutton.ForeColor = Color.LightSeaGreen;
                newbutton.Font = new Font(newbutton.Font.FontFamily, 14);
                newbutton.Location = new Point(l1, l2);
                newbutton.Name = "btn" + i;
                newbutton.Size = new Size(120, 40);
                newbutton.Text = hours[i];
                newbutton.UseVisualStyleBackColor = true;

                newbutton.Click += new EventHandler(this.button_click);
               
                fr.Controls.Add(newbutton);

                // create panel
                Panel newpanel = new Panel();

                newpanel.Size = new Size(675, 2);
                newpanel.BackColor = Color.Black;
                newpanel.Location = new Point(l1, l2 + 55);
                newpanel.Name = "pnl" + i;

                fr.Controls.Add(newpanel);

                //crerate label
                Label newlabel = new Label();
                Font newfont = new Font("Berlin Sans FB", 14);
                newlabel.ForeColor = Color.Black;
                newlabel.Font = newfont;
                newlabel.Location = new Point(l1 + 130, l2 + 10);
                newlabel.Name = "lbl" + i;
                newlabel.Text = "CAPTAIN: " + CaptainName[i] + " / PRICE: £" + prices[i] + " / FLIGHT NO: " + flightNo[i];
                newlabel.AutoSize = true;

                fr.Controls.Add(newlabel);


                l2 += 70;

            }


        }


    }
}
