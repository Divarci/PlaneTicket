using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DALayer;
using System.Windows.Forms;

namespace LogicLayer
{
    public class LLLines
    {

        public static List<string> LLLineFromList()
        {
            return DALLines.LineFromList();
        }

        public static List<string> LLLineToList(ComboBox cmb1, ComboBox cmb2)
        {
            return DALLines.LineToList(cmb1,cmb2);
        }

    }
}
