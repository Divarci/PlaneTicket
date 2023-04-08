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
        // temporary informations for return flight
        public string returnflight;
        public string from;
        public string to;
        public bool whichway;

        //Guest information
        public int tempGuestNo;


        // strill working on it
        public bool cameFrom;
        public List<string> cameFromPessengerName = new List<string>();
        public List<string> cameFromPessengerSurName = new List<string>();
        public List<string> cameFromPessengerPass = new List<string>();

        private void frmFlights_Load(object sender, EventArgs e)
        {
           
        }

       
    }
}
