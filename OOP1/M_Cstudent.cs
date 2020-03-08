using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace OOP1
{
    public abstract class M_Cstudent
    {
        public int id { get; set; }
        public string name { get; set; }

        public int Fees { get; set; }
        
        public abstract int Cost();


        public M_Events GetEvent(string tablename, int EventId, string pk)
        {
            string query = "select * from "; // Users where UserId=@UserID
            query += tablename;
            query += " where ";
            query += pk;
            query += "=@";
            query += pk;
           // MessageBox.Show(query);
            string query2 = "@" + pk;
            M_Genral.Connect.Open();
            SqlCommand command = new SqlCommand(query, M_Genral.Connect);
            command.Parameters.AddWithValue(query2, EventId);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            M_Events Eve = new M_Events();
            Eve.id = Int32.Parse(reader["EventID"].ToString());
            Eve.name = reader["Place"].ToString();
            Eve.Fees = Int32.Parse(reader["Price"].ToString());
            M_Genral.Connect.Close();
            return Eve;

        }

        public M_Buses GetBus(string tablename, int EventId, string pk)
        {
            string query = "select * from "; // Users where UserId=@UserID
            query += tablename;
            query += " where ";
            query += pk;
            query += "=@";
            query += pk;
          //  MessageBox.Show(query);
            string query2 = "@" + pk;
            M_Genral.Connect.Open();
            SqlCommand command = new SqlCommand(query, M_Genral.Connect);
            command.Parameters.AddWithValue(query2, EventId);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            M_Buses Bus = new M_Buses();
            Bus.id = Int32.Parse(reader["BusID"].ToString());
            Bus.name = reader["Destination"].ToString();
            Bus.Fees = Int32.Parse(reader["Fees"].ToString());
            M_Genral.Connect.Close();
            return Bus;

        }
    }
}
