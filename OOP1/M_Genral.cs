using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP1
{
    public class M_Genral : M_ConnSingleton
    {
         public static SqlConnection Connect = new SqlConnection("Data Source=ZEYADS-LAPTOP;Initial Catalog=Nursery;Integrated Security=True");

        M_ConnSingleton singleton = new M_ConnSingleton();
        public int SingleSelect(string tablename, int UserId, string pk)
        {

            string query = "select * from "; // Users where UserId=@UserID
            query += tablename;
            query += " where ";
            query += pk;
            query += "=@";
            query += pk;
           // MessageBox.Show(query);
            string query2 = "@" + pk;
            //Connect.Open();
            SqlCommand command = new SqlCommand(query,GetDBConnection());
            command.Parameters.AddWithValue(query2, UserId);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            /*  M_CUser MM = new M_CUser();
              MM.name = reader["Name"].ToString();
              MM.job = reader["Job_Description"].ToString();*/
            //Connect.Close();
            return UserId;
        }
        public void updateuser2(string tablename, int id, string[] atts, string[] values, string pk)
        {
            SingleSelect(tablename, id, pk);

            string query = "update " + tablename + " set ";
            for (int i = 0; i < atts.Length; i++)
            {
                if (i < atts.Length - 1)
                {
                    query += atts[i] + "=@" + atts[i] + ",";
                }
                else
                {
                    query += atts[i] + "=@" + atts[i];
                }
                //MessageBox.Show(atts[i]);
            }
            query += " where " + pk + "=@id";
          //  MessageBox.Show(query);

            //Connect.Open();
            SqlCommand command = new SqlCommand(query, GetDBConnection());
            command.Parameters.AddWithValue("@id", id);
            for (int i = 0; i < atts.Length; i++)
            {
                command.Parameters.AddWithValue(atts[i], values[i]);
            }
            command.ExecuteNonQuery();
            //Connect.Close();

        }

         public M_CUser SetTextboxes(string tablename, int UserId, string pk)
         {
            M_CUser X = new M_CUser();
            string query = "select * from "; // Users where UserId=@UserID
            query += tablename;
            query += " where ";
            query += pk;
            query += "=@";
            query += pk;
            // MessageBox.Show(query);
            string query2 = "@" + pk;
            //Connect.Open();
            SqlCommand command = new SqlCommand(query, GetDBConnection());
            command.Parameters.AddWithValue(query2, UserId);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            X.name =reader["Name"].ToString();



            //reader["Place"].ToString();
            return X;
        }


        public void ADD(string tablename, string[] Attributes, string[] values)
        {
           // Connect.Open();
            string query = "insert into ";
            query += tablename + " values";
            query += "(@";
            query += Attributes[0];
            for (int i = 1; i < Attributes.Length; i++)
            {
                query += ",@" + Attributes[i];
            }
            query += ")";
         //   MessageBox.Show(query);
            SqlCommand command = new SqlCommand(query, GetDBConnection());
            for (int i = 0; i < Attributes.Length; i++)
            {
                command.Parameters.AddWithValue("@" + Attributes[i], values[i]);
                //MessageBox.Show(Attributes[i] + "," + values[i]);
            }
            command.ExecuteNonQuery();
            //Connect.Close();
        }
        public void Delete(string tablename, int UserId, string pk)
        {

            string query = "Delete from "; // Users where UserId=@UserID
            query += tablename;
            query += " where ";
            query += pk;
            query += "=@" + pk;
          //  MessageBox.Show(query);
            //Connect.Open();
            SqlCommand command = new SqlCommand(query, GetDBConnection());
            command.Parameters.AddWithValue("@" + pk, UserId);
            command.ExecuteNonQuery();
           // Connect.Close();
        }



    }
}
