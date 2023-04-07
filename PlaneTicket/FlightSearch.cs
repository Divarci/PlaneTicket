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
using System.Data.Entity.Core.Common.CommandTrees;
using System.Security.Cryptography;
using System.Diagnostics;



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
        List<string> FlightId = new List<string>();



        public bool whichway;

        void button_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;



            
            frmSeatPlan fr = new frmSeatPlan();

            int temp = 0;

            for (int i = 0; i < hours.Count; i++)
            {
                if (btn.Text == hours[i])
                {
                    fr.Text = hours[i] + "    " + flightNo[i] + "    Seat Plan";
                    fr.tempHours = hours[i];
                    fr.tempPrices = prices[i];
                    fr.tempFno = flightNo[i];
                    fr.tempCaptain = CaptainName[i];
                    fr.tempGuestNo = Convert.ToInt16(numGuest.Value);
                    fr.FID = FlightId[i];
                    List<string> SeatInfo = LLSeats.LLSeatInforation(FlightId[i]);
                    temp = SeatInfo.Count;
                    fr.firstFlightHour = hours[i];
                    fr.returnflight =dtpReturn.Text;
                    fr.from = cmbTo.Text;
                    fr.to = cmbFrom.Text;
                }

            }
            if (12 - temp < numGuest.Value)
            {
                MessageBox.Show("There is not enough seat for this flight. Please choose another one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                fr.Show();
            }
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
            rbOneway.Checked = true;


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

            if (rbOneway.Checked)
            {

                whichway = true;
            }
            else
            {
                whichway = false;
            }

            hours.Clear();
            prices.Clear();
            flightNo.Clear();
            CaptainName.Clear();
            FlightId.Clear();

            List<int> values = new List<int>();
            LLFlights.LLCatchFlightNumber(cmbFrom.Text, cmbTo.Text, dtpDep.Text, values);
            if (values.Count == 0)
            {
                MessageBox.Show("Please change your flight date or location", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                int lineId = values[1];
                int flightNumber = values[0];

                // added flight hours in a temp list

                LLFlights.LLCatchFlightInfos(hours, prices, flightNo, CaptainName, FlightId, lineId);

                frmFlights fr = new frmFlights();
                fr.returnflight = dtpReturn.Text;
                fr.from = cmbTo.Text;
                fr.to = cmbFrom.Text;
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


                fr.Show();



            }


        }

        private void rbOneway_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOneway.Checked == true)
            {
                dtpReturn.Enabled = false;
            }
        }

        private void rbReturn_CheckedChanged(object sender, EventArgs e)
        {
            if (rbReturn.Checked == true)
            {
                dtpReturn.Enabled = true;
            }
        }

        private void dtpReturn_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
