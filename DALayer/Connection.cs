﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer
{
    public class Connection
    {

        public static SqlConnection conn = new SqlConnection(@"Data Source=HASAN-DERS\SQLEXPRESS;Initial Catalog=TicketBuy;Integrated Security=True");

    }
}
