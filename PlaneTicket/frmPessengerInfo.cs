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

namespace PlaneTicket
{
    public partial class frmPessengerInfo : Form
    {
        public frmPessengerInfo()
        {
            InitializeComponent();
        }
        public int tempGuestNo;
        public int[] tempSeatNo = new int[12];
        public string FID;


        private void frmPessengerInfo_Load(object sender, EventArgs e)
        {


            ComboBox[] cmbSeat = { cmbS1, cmbS2, cmbS3, cmbS4, cmbS5, cmbS6, cmbS7, cmbS8, cmbS9, cmbS10, cmbS11, cmbS12 };
            TextBox[] txtNames = { txtName1, txtName2, txtName3, txtName4, txtName5, txtName6, txtName7, txtName8, txtName9, txtName10, txtName11, txtName12 };
            TextBox[] txtSurNames = { txtSurname1, txtSurname2, txtSurname3, txtSurname4, txtSurname5, txtSurname6, txtSurname7, txtSurname8, txtSurname9, txtSurname10, txtSurname11, txtSurname12 };
            TextBox[] txtPassports = { txtPassport1, txtPassport2, txtPassport3, txtPassport4, txtPassport5, txtPassport6, txtPassport7, txtPassport8, txtPassport9, txtPassport10, txtPassport11, txtPassport12 };

            for (int i = tempGuestNo; i < 12; i++)
            {
                txtNames[i].Enabled = false;
                txtSurNames[i].Enabled = false;
                txtPassports[i].Enabled = false;
                cmbSeat[i].Enabled = false;


            }
            for (int y = 0; y < cmbSeat.Length; y++)
            {

                for (int i = 0; i < tempSeatNo.Length; i++)
                {
                    if (tempSeatNo[i] != 0)
                    {
                        cmbSeat[y].Items.Add(tempSeatNo[i]);
                    }

                }

            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void register(TextBox name, TextBox surname, TextBox pass, ComboBox seat)
        {

            EntitySeats values = new EntitySeats();

            values.PessengerName = name.Text;
            values.PessengerSurname = surname.Text;
            values.PassportNuber = pass.Text;

            LLSeats.LLSeatUpdate(values, FID, seat.Text);




        }
        public string firstFlightHour;

        public List<string> hours2 = new List<string>();
        public List<string> prices2 = new List<string>();
        public List<string> flightNo2 = new List<string>();
        public List<string> CaptainName2 = new List<string>();
        public List<string> FlightId2 = new List<string>();

        public int flightNumberReturn;

        void button_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            frmSeatPlan fr = new frmSeatPlan();
            int temp = 0;
            if (Convert.ToDateTime(firstFlightHour).TimeOfDay <= Convert.ToDateTime(btn.Text).TimeOfDay)
            {
                MessageBox.Show("You should select a flight after your deperture", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                    }

                }
                if (12 - temp < tempGuestNo)
                {
                    MessageBox.Show("There is not enough seat for this flight. Please choose another one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    frmFlights frtemp = new frmFlights();
                    frtemp.Close();
                    fr.Show();
                }
            }
            
        }
        private void btnReserve_Click(object sender, EventArgs e)
        {
            

            TextBox[] txtNameBoxes = { txtName1, txtName2, txtName3, txtName4, txtName5, txtName6, txtName7, txtName8, txtName9, txtName10, txtName11, txtName12 };
            TextBox[] txtSurNameBoxes = { txtSurname1, txtSurname2, txtSurname3, txtSurname4, txtSurname5, txtSurname6, txtSurname7, txtSurname8, txtSurname9, txtSurname10, txtSurname11, txtSurname12 };
            TextBox[] txtPassBoxes = { txtPassport1, txtPassport2, txtPassport3, txtPassport4, txtPassport5, txtPassport6, txtPassport7, txtPassport8, txtPassport9, txtPassport10, txtPassport11, txtPassport12 };
            ComboBox[] SeatBoxes = { cmbS1, cmbS2, cmbS3, cmbS4, cmbS5, cmbS6, cmbS7, cmbS8, cmbS9, cmbS10, cmbS11, cmbS12 };
            int tempvalue = 0;
            int tempvalue2 = 0;
            for (int i = 0; i < tempGuestNo; i++)
            {
                for (int y = 0; y < tempGuestNo; y++)
                {
                    if (SeatBoxes[i].Text == SeatBoxes[y].Text)
                    {
                        tempvalue++;
                    }
                }
                if (txtNameBoxes[i].Text == "" || txtSurNameBoxes[i].Text == "" || txtPassBoxes[i].Text == "" || SeatBoxes[i].Text == "")
                {
                    tempvalue2++;
                }
            }
            if (tempvalue2 > 0)
            {
                MessageBox.Show("Please provide all informationa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (tempvalue > tempGuestNo)
                {
                    MessageBox.Show("You cannot select same seat for same pessenger", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    for (int i = 0; i < txtNameBoxes.Length; i++)
                    {
                        if (txtNameBoxes[i].Enabled)
                        {

                            register(txtNameBoxes[i], txtSurNameBoxes[i], txtPassBoxes[i], SeatBoxes[i]);

                        }
                    }
                    FlightSearch fr = new FlightSearch();
                    if (fr.whichway)
                    {
                        MessageBox.Show("You have booked your Seats. Have a nice fligt", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("You have booked your OUTBOUND flight. Please Click OK to choose INBOUND flight", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MessageBox.Show(flightNumberReturn.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();

                        frmFlights frfl = new frmFlights();

                       
                        int l1 = 20;
                        int l2 = 20;
                        for (int i = 0; i < flightNumberReturn; i++)
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

                        frfl.Show();
                    }
                }
            }

        }
    }
}
