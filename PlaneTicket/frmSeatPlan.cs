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
        int greenButtonNo = 0;
        void btnCLickColor(Button btn)
        {
            if (btn.BackColor == Color.MistyRose)
            {
                if (greenButtonNo == tempGuestNo)
                {
                    MessageBox.Show("You have reached maximum Selected person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    btn.BackColor = Color.Green;
                    btn.ForeColor = Color.White;
                    greenButtonNo++;
                }

            }

            else if (btn.BackColor == Color.Crimson)
            {
                MessageBox.Show("Seat has already been taken by another person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (btn.BackColor == Color.Green)
            {
                btn.BackColor = Color.MistyRose;
                btn.ForeColor = Color.Black;
                greenButtonNo--;
            }
        }
        double totalPrice = 0;

        void btnPriceCalculation(Button btn2)
        {

            if (btn2.BackColor == Color.Green)
            {
                totalPrice = totalPrice + Convert.ToDouble(tempPrices);
                lblPrice.Text = totalPrice.ToString();

            }
            else if (btn2.BackColor == Color.MistyRose)
            {
                totalPrice = totalPrice - Convert.ToDouble(tempPrices);
                lblPrice.Text = totalPrice.ToString();
            }
        }

        public string tempHours, tempFno, tempCaptain, tempPrices, FID;

        private void btnS3_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS3);
        }

        private void btnS4_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS4);
        }

        private void btnS5_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS5);
        }

        private void btnS6_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS6);
        }

        private void btnS7_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS7);
        }

        private void btnS8_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS8);
        }

        private void btnS9_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS9);
        }

        private void btnS10_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS10);
        }

        private void btnS11_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS11);
        }

        private void btnS12_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS12);
        }

        private void btnS1_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS1);
        }

        private void btnS2_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS2);
        }

        private void btnS3_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS3);
        }

        private void btnS4_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS4);
        }

        private void btnS5_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS5);
        }

        private void btnS6_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS6);
        }

        private void btnS7_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS7);
        }

        private void btnS8_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS8);
        }

        private void btnS9_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS9);
        }

        private void btnS10_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS10);
        }

        private void btnS11_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS11);
        }

        private void btnS12_BackColorChanged(object sender, EventArgs e)
        {
            btnPriceCalculation(btnS12);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int tempGuestNo;
        private void btnReserve_Click(object sender, EventArgs e)
        {
            if(greenButtonNo != tempGuestNo)
            {
                MessageBox.Show("Please select seats for all pessengers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int[] tempSeatNo = new int[12];
                Button[] btnTemp = { btnS1, btnS2, btnS3, btnS4, btnS5, btnS6, btnS7, btnS8, btnS9, btnS10, btnS11, btnS12 };
                frmPessengerInfo fr = new frmPessengerInfo();
                fr.FID = FID;
                fr.tempGuestNo = tempGuestNo;
                for (int i = 0; i < btnTemp.Length; i++)
                {
                    if (btnTemp[i].BackColor == Color.Green)
                    {
                        tempSeatNo[i] = i + 1;
                    }
                }
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

        private void btnS2_Click(object sender, EventArgs e)
        {
            btnCLickColor(btnS2);
        }

        private void btnS1_MouseClick(object sender, MouseEventArgs e)
        {
            btnCLickColor(btnS1);
        }

        private void frmSeatPlan_Load(object sender, EventArgs e)
        {
            frmFlights fr = new frmFlights();
            fr.Close();

            lblHour.Text = tempHours;
            lblFno.Text = tempFno;
            lblCaptain.Text = tempCaptain;

            Button[] btnTemp = { btnS1, btnS2, btnS3, btnS4, btnS5, btnS6, btnS7, btnS8, btnS9, btnS10, btnS11, btnS12 };

            List<string> SeatValues = new List<string>();

            LLSeats.ReservedSeats(FID, SeatValues);
            
            
            /*
            List<string> pessengerNames = new List<string>();
            List<string> seatNumber = new List<string>();
            SqlCommand cmd = new SqlCommand("Select pessengerName from Tbl_Seats where flightId=@p1", Connection.conn);
            cmd.Parameters.AddWithValue("@p1", FID);
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                pessengerNames.Add(dr[0].ToString());
                
            }
            cmd.Connection.Close();
            */
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
