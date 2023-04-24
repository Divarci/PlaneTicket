using DALayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;
using EntityLayer;
using LogicLayer;
using Button = System.Windows.Forms.Button;
using System.Diagnostics;


namespace PlaneTicket
{
    public partial class frmPessengerInfo : Form
    {
        public frmPessengerInfo()
        {
            InitializeComponent();
        }
        //We received guest number
        public int tempGuestNo;
        //We received choosen seats
        public int[] tempSeatNo = new int[12];
        //We received Flight Id
        public string FID;
        //We received Oneway or return
        public bool whichway;

        private void frmPessengerInfo_Load(object sender, EventArgs e)
        {



            //All comboboxes and textboxes assigned to arrays as we will use for loops
            ComboBox[] cmbSeat = { cmbS1, cmbS2, cmbS3, cmbS4, cmbS5, cmbS6, cmbS7, cmbS8, cmbS9, cmbS10, cmbS11, cmbS12 };
            TextBox[] txtNames = { txtName1, txtName2, txtName3, txtName4, txtName5, txtName6, txtName7, txtName8, txtName9, txtName10, txtName11, txtName12 };
            TextBox[] txtSurNames = { txtSurname1, txtSurname2, txtSurname3, txtSurname4, txtSurname5, txtSurname6, txtSurname7, txtSurname8, txtSurname9, txtSurname10, txtSurname11, txtSurname12 };
            TextBox[] txtPassports = { txtPassport1, txtPassport2, txtPassport3, txtPassport4, txtPassport5, txtPassport6, txtPassport7, txtPassport8, txtPassport9, txtPassport10, txtPassport11, txtPassport12 };
            // we will make false unnecessary items.
            for (int i = tempGuestNo; i < 12; i++)
            {
                txtNames[i].Enabled = false;
                txtSurNames[i].Enabled = false;
                txtPassports[i].Enabled = false;
                cmbSeat[i].Enabled = false;
            }
            //add tempseatno information to all comboboxes
            for (int y = 0; y < cmbSeat.Length; y++)
            {

                for (int i = 0; i < tempSeatNo.Length; i++)
                {
                    //eliminating values equal to 0 as rest of them our seat numbers
                    if (tempSeatNo[i] != 0)
                    {
                        cmbSeat[y].Items.Add(tempSeatNo[i]);
                    }

                }

            }
            if (cameFrom == false)
            {
                for (int i = 0; i < cameFromPessengerName.Count; i++)
                {
                    txtNames[i].Text = cameFromPessengerName[i];
                    txtSurNames[i].Text = cameFromPessengerSurName[i];
                    txtPassports[i].Text = cameFromPessengerPass[i];

                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void register(TextBox name, TextBox surname, TextBox pass, ComboBox seat)
        {
            // save pessenger method using Update method 
            EntitySeats values = new EntitySeats();

            values.PessengerName = name.Text;
            values.PessengerSurname = surname.Text;
            values.PassportNuber = pass.Text;

            LLSeats.LLSeatUpdate(values, FID, seat.Text);

        }


        //needed for return flight
        List<string> hours2 = new List<string>();
        List<string> prices2 = new List<string>();
        List<string> flightNo2 = new List<string>();
        List<string> CaptainName2 = new List<string>();
        List<string> FlightId2 = new List<string>();
        //carries info from first flight
        public List<string> cameFromPessengerName = new List<string>();
        public List<string> cameFromPessengerSurName = new List<string>();
        public List<string> cameFromPessengerPass = new List<string>();
        /*
        public string[] cameFromPessengerName = new string[12];
        public string[] cameFromPessengerSurName = new string[12];
        public string[] cameFromPessengerPass = new string[12];
        */

        //Needed for return flight
        public string returnflight;
        public string from;
        public string to;
        public string firstFlightHour;
        public bool cameFrom;


        //dynamic button actions
        void button_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            frmSeatPlan fr = new frmSeatPlan();

            int temp = 0;
            //prevent choosing return flight hours before it.
            if (Convert.ToDateTime(firstFlightHour).TimeOfDay >= Convert.ToDateTime(btn.Text).TimeOfDay)
            {
                MessageBox.Show("You should select a flight after your deperture", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //if it is not(same as before we explined at flight search page)
            else
            {
                for (int i = 0; i < hours2.Count; i++)
                {
                    if (btn.Text == hours2[i])
                    {
                        fr.Text = hours2[i] + "    " + flightNo2[i] + "    Seat Plan";
                        fr.tempHours = hours2[i];
                        fr.tempPrices = prices2[i];
                        fr.tempFno = flightNo2[i];
                        fr.tempCaptain = CaptainName2[i];
                        fr.tempGuestNo = Convert.ToInt16(tempGuestNo);
                        fr.FID = FlightId2[i];
                        List<string> SeatInfo = LLSeats.LLSeatInforation(FlightId2[i]);
                        temp = SeatInfo.Count;
                        //it makes bool true and when it came to save pessenger after return flight. algortm calculate it like one way and finish the register
                        fr.whichway = true;
                        //still working on it
                        fr.cameFrom = false;
                        fr.cameFromPessengerName.AddRange(cameFromPessengerName);
                        fr.cameFromPessengerSurName.AddRange(cameFromPessengerSurName);
                        fr.cameFromPessengerPass.AddRange(cameFromPessengerPass);

                    }

                }
                if (12 - temp < tempGuestNo)
                {
                    MessageBox.Show("There is not enough seat for this flight. Please choose another one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    fr.Show();
                }
            }

        }

        //Save Button
        private void btnReserve_Click(object sender, EventArgs e)
        {
            TextBox[] txtNameBoxes = { txtName1, txtName2, txtName3, txtName4, txtName5, txtName6, txtName7, txtName8, txtName9, txtName10, txtName11, txtName12 };
            TextBox[] txtSurNameBoxes = { txtSurname1, txtSurname2, txtSurname3, txtSurname4, txtSurname5, txtSurname6, txtSurname7, txtSurname8, txtSurname9, txtSurname10, txtSurname11, txtSurname12 };
            TextBox[] txtPassBoxes = { txtPassport1, txtPassport2, txtPassport3, txtPassport4, txtPassport5, txtPassport6, txtPassport7, txtPassport8, txtPassport9, txtPassport10, txtPassport11, txtPassport12 };
            ComboBox[] SeatBoxes = { cmbS1, cmbS2, cmbS3, cmbS4, cmbS5, cmbS6, cmbS7, cmbS8, cmbS9, cmbS10, cmbS11, cmbS12 };

            //will be used for create algoritm prevent choose same values at seats and make empty values for textboxes
            int tempvalue = 0;
            int tempvalue2 = 0;
            //all comboboxes will be matches between eachothers and when loop is finished and if every combobox values are different tempvalue should be 2

            for (int i = 0; i < tempGuestNo; i++)
            {
                for (int y = 0; y < tempGuestNo; y++)
                {
                    if (SeatBoxes[i].Text == SeatBoxes[y].Text)
                    {
                        tempvalue++;
                    }
                }
                //if tempvalue2 is bigger than 0 it means we have empty textbox
                if (txtNameBoxes[i].Text == "" || txtSurNameBoxes[i].Text == "" || txtPassBoxes[i].Text == "" || SeatBoxes[i].Text == "")
                {
                    tempvalue2++;
                }
            }

            //if we have empty textbox
            if (tempvalue2 > 0)
            {
                MessageBox.Show("Please provide all informationa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //if it is not
            else
            {
                //if we have same seat number for different guests
                if (tempvalue > tempGuestNo)
                {
                    MessageBox.Show("You cannot select same seat for same pessenger", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //if it is not
                else
                {

                    for (int i = 0; i < txtNameBoxes.Length; i++)
                    {
                        //we made false unnecessary items, so now we will just choose the enabled ones
                        if (txtNameBoxes[i].Enabled)
                        {
                            register(txtNameBoxes[i], txtSurNameBoxes[i], txtPassBoxes[i], SeatBoxes[i]);
                            //if flight with return
                            if (whichway == false)
                            {
                                cameFromPessengerName.Add(txtNameBoxes[i].Text);
                                cameFromPessengerSurName.Add(txtSurNameBoxes[i].Text);
                                cameFromPessengerPass.Add(txtPassBoxes[i].Text);

                            }


                        }
                    }
                    // if its one way 
                    if (whichway)
                    {
                        MessageBox.Show("You have booked your Seats. Have a nice fligt", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Application.Restart();
                    }
                    // if we have return flight (same as flight search page)
                    else
                    {
                        MessageBox.Show("You have booked your OUTBOUND flight. Please Click OK to choose INBOUND flight", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        hours2.Clear();
                        prices2.Clear();
                        flightNo2.Clear();
                        CaptainName2.Clear();
                        FlightId2.Clear();

                        List<int> values = new List<int>();
                        LLFlights.LLCatchFlightNumber(from, to, returnflight, values);


                        int lineId = values[1];
                        int flightNumber = values[0];

                        // added flight hours in a temp list

                        LLFlights.LLCatchFlightInfos(hours2, prices2, flightNo2, CaptainName2, FlightId2, lineId);

                        frmFlights frfl = new frmFlights();
                        frfl.whichway = true;
                        frfl.cameFrom = false;

                        frfl.cameFromPessengerName.AddRange(cameFromPessengerName);
                        frfl.cameFromPessengerSurName.AddRange(cameFromPessengerSurName);
                        frfl.cameFromPessengerPass.AddRange(cameFromPessengerPass);

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
                            newbutton.Text = hours2[i];
                            newbutton.UseVisualStyleBackColor = true;

                            newbutton.Click += new EventHandler(this.button_click);

                            frfl.Controls.Add(newbutton);

                            // create panel
                            Panel newpanel = new Panel();

                            newpanel.Size = new Size(675, 2);
                            newpanel.BackColor = Color.Black;
                            newpanel.Location = new Point(l1, l2 + 55);
                            newpanel.Name = "pnl" + i;

                            frfl.Controls.Add(newpanel);

                            //crerate label
                            Label newlabel = new Label();
                            Font newfont = new Font("Berlin Sans FB", 14);
                            newlabel.ForeColor = Color.Black;
                            newlabel.Font = newfont;
                            newlabel.Location = new Point(l1 + 130, l2 + 10);
                            newlabel.Name = "lbl" + i;
                            newlabel.Text = "CAPTAIN: " + CaptainName2[i] + " / PRICE: £" + prices2[i] + " / FLIGHT NO: " + flightNo2[i];
                            newlabel.AutoSize = true;

                            frfl.Controls.Add(newlabel);


                            l2 += 70;

                        }
                        this.Close();
                        frfl.Show();
                    }
                }
            }

        }
    }
}
