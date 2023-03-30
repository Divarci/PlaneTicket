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
    public partial class frmSeatPlan : Form
    {
        public frmSeatPlan()
        {
            InitializeComponent();
        }
        public string a,b,c,d;
        private void frmSeatPlan_Load(object sender, EventArgs e)
        {
            label1.Text = a;
            label2.Text = b;
            label3.Text = c;
            label4.Text = d;
        }
    }
}
