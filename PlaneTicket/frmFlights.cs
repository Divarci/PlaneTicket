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
    public partial class frmFlights : Form
    {
        public frmFlights()
        {
            InitializeComponent();
        }

        public string returnflight;
        public string from;
        public string to;

        public int tempGuestNo;
        
        private void frmFlights_Load(object sender, EventArgs e)
        {
           
        }

       
    }
}
