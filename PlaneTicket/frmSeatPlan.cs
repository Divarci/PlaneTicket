using DALayer;
using LogicLayer;
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

namespace PlaneTicket
{
    public partial class frmSeatPlan : Form
    {
        public frmSeatPlan()
        {
            InitializeComponent();
        }
        // seat selection algolritm
        int greenButtonNo = 0;

        //temporary return flight informations
        public string returnflight;
        public string from;
        public string to;
        public string firstFlightHour;
        public bool whichway;

        //still working on it
        public bool cameFrom = true;
        public List<string> cameFromPessengerName = new List<string>();
        public List<string> cameFromPessengerSurName = new List<string>();
        public List<string> cameFromPessengerPass = new List<string>();

        // will be used for algoritm both seat selection and reserve seat
        public int tempGuestNo;

        //Seat selection algortim related to back color of button
        void btnCLickColor(Button btn)
        {
            //when clicked if the seat is available
            if (btn.BackColor == Color.MistyRose)
            {
                //if selected seats equal to guest no
                if (greenButtonNo == tempGuestNo)
                {
                    MessageBox.Show("You have reached maximum Selected person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //if it is not seat will green and greenbuttonno will be increase 1
                else
                {
                    btn.BackColor = Color.Green;
                    btn.ForeColor = Color.White;
                    greenButtonNo++;
                }

            }
            // when clicked if seat is booked
            else if (btn.BackColor == Color.Crimson)
            {
                MessageBox.Show("Seat has already been taken by another person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //when clicked if seat is reserved by current guest, seat will be released and greenbuttonno will be decrase 1
            else if (btn.BackColor == Color.Green)
            {
                btn.BackColor = Color.MistyRose;
                btn.ForeColor = Color.Black;
                greenButtonNo--;
            }
        }

        // keps price information
        double totalPrice = 0;
        // we received those temporary informations when we clicked dynamic buttons when we did flight search
        public string tempHours, tempFno, tempCaptain, tempPrices, FID;

        // it calculates the prices according to buttons color as we managed seat colours
        void btnPriceCalculation(Button btn2)
        {
            //when clicked a button first button color will be changed then this method will be run

            //when clicked and if button is reserved by guest, total price will be icreased by clicked flight price
            if (btn2.BackColor == Color.Green)
            {
                totalPrice = totalPrice + Convert.ToDouble(tempPrices);
                lblPrice.Text = totalPrice.ToString();

            }
            //when clicked and if button is released by guest, total price will be decreased by clicked flight price
            else if (btn2.BackColor == Color.MistyRose)
            {
                totalPrice = totalPrice - Convert.ToDouble(tempPrices);
                lblPrice.Text = totalPrice.ToString();
            }
        }

        //seat 1 click action
        private void btnS1_MouseClick(object sender, MouseEventArgs e)
        {
            btnCLickColor(btnS1);
        }
        //seat 2 click action
        private void btnS2_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS2);
        }
        //seat 3 click action
        private void btnS3_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS3);
        }
        //seat 4 click action
        private void btnS4_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS4);
        }
        //seat 5 click action
        private void btnS5_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS5);
        }
        //seat 6 click action
        private void btnS6_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS6);
        }
        //seat 7 click action
        private void btnS7_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS7);
        }
        //seat 8 click action
        private void btnS8_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS8);
        }
        //seat 9 click action
        private void btnS9_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS9);
        }
        //seat 10 click action
        private void btnS10_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS10);
        }
        //seat 11 click action
        private void btnS11_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS11);
        }
        //seat 12 click action
        private void btnS12_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS12);
        }
        //seat 1 color change action
        private void btnS1_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS1);
        }
        //seat 2 color change action
        private void btnS2_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS2);
        }
        //seat 3 color change action
        private void btnS3_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS3);
        }
        //seat 4 color change action
        private void btnS4_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS4);
        }
        //seat 5 color change action
        private void btnS5_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS5);
        }
        //seat 6 color change action
        private void btnS6_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS6);
        }
        //seat 7 color change action
        private void btnS7_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS7);
        }
        //seat 8 color change action
        private void btnS8_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS8);
        }
        //seat 9 color change action
        private void btnS9_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS9);
        }
        //seat 10 color change action
        private void btnS10_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS10);
        }
        //seat 11 color change action
        private void btnS11_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS11);
        }
        //seat 12 color change action
        private void btnS12_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS12);
        }
        //exit seat plans
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // seat reserve
        private void btnReserve_Click(object sender, EventArgs e)
        {
            // There is an elimination to make guest to select seats for all guests.
            //if it is not there is an error
            if (greenButtonNo != tempGuestNo)
            {
                MessageBox.Show("Please select seats for all pessengers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //it it is selected
            else
            {
                frmPessengerInfo fr = new frmPessengerInfo();
                //send return informations to pessengerinfo page
                fr.returnflight = returnflight;
                fr.from = from;
                fr.to = to;
                fr.whichway = whichway;
                fr.firstFlightHour = firstFlightHour;
                //still working on it
                fr.cameFrom = cameFrom;
                fr.cameFromPessengerName.AddRange(cameFromPessengerName);
                fr.cameFromPessengerSurName.AddRange(cameFromPessengerSurName);
                fr.cameFromPessengerPass.AddRange(cameFromPessengerPass);

                //send informations for pessenger register
                fr.FID = FID;
                fr.tempGuestNo = tempGuestNo;

                
                Button[] btnTemp = { btnS1, btnS2, btnS3, btnS4, btnS5, btnS6, btnS7, btnS8, btnS9, btnS10, btnS11, btnS12 };
                int[] tempSeatNo = new int[12];
                //reserved seats assigned new array as its seat number. available seats asre assigned 0
                for (int i = 0; i < btnTemp.Length; i++)
                {
                    if (btnTemp[i].BackColor == Color.Green)
                    {
                        tempSeatNo[i] = i + 1;
                    }
                }

                //We eliminate 0 values and send new values to an array in located pessenger page
                for (int y = 0; y < tempSeatNo.Length; y++)
                {
                    if (tempSeatNo[y] > 0)
                    {
                        fr.tempSeatNo[y] = tempSeatNo[y];
                    }
                }
               
                fr.Show();
                this.Close();
            }


        }
        //load infos
        private void frmSeatPlan_Load(object sender, EventArgs e)
        {
            
            // assign infos to the labes
            lblHour.Text = tempHours;
            lblFno.Text = tempFno;
            lblCaptain.Text = tempCaptain;

            //We assigned all buttons(seats) to an array
            Button[] btnTemp = { btnS1, btnS2, btnS3, btnS4, btnS5, btnS6, btnS7, btnS8, btnS9, btnS10, btnS11, btnS12 };

            //we pulled informations which seats are reserved
            List<string> SeatValues = new List<string>();
            LLSeats.ReservedSeats(FID, SeatValues);

            //we made unchangeable and red color seats which is booked before
            for (int i = 0; i < SeatValues.Count; i++)
            {
                if (SeatValues[i].Length != 0 || SeatValues[i] != string.Empty)
                {
                    btnTemp[i].BackColor = Color.Red;
                    btnTemp[i].Enabled = false;
                }
            }
        }
    }
}
