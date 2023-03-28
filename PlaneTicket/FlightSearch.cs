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

namespace PlaneTicket
{
    public partial class FlightSearch : Form
    {
        public FlightSearch()
        {
            InitializeComponent();
        }

       
        private void FlightSearch_Load(object sender, EventArgs e)
        {

           
            comboBox1.DataSource = LLLines.LLLineFromList();
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            LLLines.LLLineToList(comboBox1, comboBox2);
            
        }
    }
}
