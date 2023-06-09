﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Collections;

namespace DALayer
{
    public class DALSeats
    {
        //save pessenger using update method
        public static bool DALSeatUpdate(EntitySeats Seats, string FNO, string seatno)
        {
            SqlCommand cmd = new SqlCommand("Update Tbl_Seats set pessengerName=@p1,pessengerSurname=@p2,passportNumber=@p3 where flightId=@p4 and seatNumber=@p5", Connection.conn);
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            cmd.Parameters.AddWithValue("@p1", Seats.PessengerName);
            cmd.Parameters.AddWithValue("@p2", Seats.PessengerSurname);
            cmd.Parameters.AddWithValue("@p3", Seats.PassportNuber);
            cmd.Parameters.AddWithValue("@p4", FNO);
            cmd.Parameters.AddWithValue("@p5", seatno);

            return cmd.ExecuteNonQuery() > 0;
        }
        //assign pessenger names to a list that belongs to a specific flightid
        public static void DALReservedSeats(string FID, List<string> values)
        {

            SqlCommand cmd = new SqlCommand("Select pessengerName from Tbl_Seats where flightId=@p1", Connection.conn);
            cmd.Parameters.AddWithValue("@p1", FID);
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                values.Add(dr[0].ToString());

            }
            cmd.Connection.Close();

        }
        //counts how many seat is booked

        public static List<string> DALSeatInformaion(string FID)
        {
            List<string> values = new List<string>();
            SqlCommand cmd = new SqlCommand("Select pessengerName from Tbl_Seats where flightId=@p1", Connection.conn);
            cmd.Parameters.AddWithValue("@p1", FID);
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                values.Add(dr[0].ToString());
                


            }
            values.RemoveAll(item => string.IsNullOrEmpty(item));
            cmd.Connection.Close();
            return values;
        }
    }
}
