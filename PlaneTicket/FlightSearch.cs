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


        // when form loaded command listed below will be run

        private void FlightSearch_Load(object sender, EventArgs e)
        {
            rbOneway.Checked = true;
            cmbFrom.DataSource = LLLines.LLLineFromList();
        }

        // When selected departure location from cmbFrom, Target location will be added to cmbTo

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLLines.LLLineToList(cmbFrom, cmbTo);
        }


        List<string> hours = new List<string>();
        List<string> prices = new List<string>();
        List<string> flightNo = new List<string>();
        List<string> CaptainName = new List<string>();
        List<string> FlightId = new List<string>();

        public bool whichway;
        private void btnFindCheapFlight_Click(object sender, EventArgs e)
        {
            // First make cleaning for all list to make a fresh start.
            hours.Clear();
            prices.Clear();
            flightNo.Clear();
            CaptainName.Clear();
            FlightId.Clear();

            List<int> depValues = new List<int>();
            List<int> returnValues = new List<int>();

            //Second checks is this fligt one way or with return.
            if (rbOneway.Checked)
            {
                //one-way
                whichway = true;

                //Makes a selection of lineId and flightNumbers according to selected departure,target location and flight date and assign them a list which is named depValues
                LLFlights.LLCatchFlightNumber(cmbFrom.Text, cmbTo.Text, dtpDep.Text, depValues);
            }
            else
            {
                //return
                whichway = false;
                //Makes a selection of lineId and flightNumbers according to selected departure,target location and flight date and assign them a list which is named depValues
                LLFlights.LLCatchFlightNumber(cmbFrom.Text, cmbTo.Text, dtpDep.Text, depValues);
                //Makes a selection of lineId and flightNumbers according to selected return,target location and flight date and assign them a list which is named returnValues
                LLFlights.LLCatchFlightNumber(cmbTo.Text, cmbFrom.Text, dtpReturn.Text, returnValues);
            }
            


            // if values comes with 0 item it means there is no flight related to location or date

            if (depValues.Count == 0)
            {
                MessageBox.Show("Please change departure your flight date or location", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (rbReturn.Checked)
            {
                // if values comes with 0 item it means there is no return flight related to location or date
                if (returnValues.Count == 0)
                {
                    MessageBox.Show("Please change your return flight date or location", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            // if there is a flight
            if ((depValues.Count !=0 && rbOneway.Checked) || (depValues.Count !=0 && returnValues.Count !=0) )
            {

                // if there is aflight we assign lineId and flightnumber to variables.

                int lineId = depValues[1];
                int flightNumber = depValues[0];

                // Once we know the flight id we can select all flight infos.

                LLFlights.LLCatchFlightInfos(hours, prices, flightNo, CaptainName, FlightId, lineId);

                frmFlights fr = new frmFlights();

                // these 4 assigntments will be work if flight with return is  choosen. Othervise values wont effect the result
                fr.returnflight = dtpReturn.Text;
                fr.from = cmbTo.Text;
                fr.to = cmbFrom.Text;
                fr.whichway = whichway;


                // these variables for start location values for synamic objects.
                int l1 = 20;
                int l2 = 20;

                // Now we know how many flightNumber we have and we need to create button for all of them.

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

                    //button click action( button_click is designed for this action please look at that)
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

                    // this value is adjusted to 70 to move new items littlebit more down.
                    l2 += 70;

                }

                //and we open flights page

                fr.Show();
            }
        }

        // dynamic button commands

        void button_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            frmSeatPlan fr = new frmSeatPlan();

            int temp = 0;

            // this click action will be used for all new button and i need to send flght informations to seatplan page according to selected flight. That is why i used for loop. it is scanning all flight hours and if clicked button.text equal to the item of Hours list, it means we catch the information of that flight.and i sent all information i would have needed.

            for (int i = 0; i < hours.Count; i++)
            {
                if (btn.Text == hours[i])
                {
                    // informations for seatplan page
                    fr.Text = hours[i] + "    " + flightNo[i] + "    Seat Plan";
                    fr.tempHours = hours[i];
                    fr.tempPrices = prices[i];
                    fr.tempFno = flightNo[i];
                    fr.tempCaptain = CaptainName[i];
                    fr.tempGuestNo = Convert.ToInt16(numGuest.Value);
                    fr.FID = FlightId[i];
                    // counts how many seat is booked
                    List<string> SeatInfo = LLSeats.LLSeatInforation(FlightId[i]);
                    temp = SeatInfo.Count;
                    //keeps first flight hour information for return flight not to choose a flight before departure if choosen same day flights
                    fr.firstFlightHour = hours[i];

                    //send information related to return flight
                    fr.returnflight = dtpReturn.Text;
                    fr.from = cmbTo.Text;
                    fr.to = cmbFrom.Text;
                    fr.whichway = whichway;
                }
            }

            //12-temp is available seat. this if-else command block eliminate the an error if we dont have any available seats.
            if (12 - temp < numGuest.Value)
            {
                MessageBox.Show("There is not enough seat for this flight. Please choose another one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                fr.Show();
            }
        }


        // If oneway checked, date return will be false 
        private void rbOneway_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOneway.Checked == true)
            {
                dtpReturn.Enabled = false;
            }
        }

        // If return checked, date return will be true
        private void rbReturn_CheckedChanged(object sender, EventArgs e)
        {
            if (rbReturn.Checked == true)
            {
                dtpReturn.Enabled = true;
            }
        }


    }
}
