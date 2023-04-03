using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaneTicket
{
    public partial class frmPessengerInfo : Form
    {
        public frmPessengerInfo()
        {
            InitializeComponent();
        }
        public int tempGuestNo;
       //public int[] tempSeatNo;
       public List<int> tempSeatNo = new List<int>();
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
                
                    cmbSeat[y] = tempSeatNo;
                
                
                cmbSeat[y].Text = "";
            }


        }
    }
}
