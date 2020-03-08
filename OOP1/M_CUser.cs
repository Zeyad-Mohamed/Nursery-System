using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace OOP1
{
    public partial class M_CUser 
    {
        
        public string name { get; set; }
        public string password { get; set; }
        public string job { get; set; }

        public int id { get; set; }

        private static SqlConnection Connect = new SqlConnection("Data Source=ZEYADS-LAPTOP;Initial Catalog=Nursery;Integrated Security=True");
        public bool Valid()
        {
            if (name != null && password != null && job != null)
            {
                
                return true;
            }
            else
                return false;

        }

        public bool Login(M_CUser UL)
        {
            
           foreach(var i in M_CUser.allUsers())
           {
                if ( i.name == UL.name && i.password == UL.password)
                {
                    return true;
                }
           }
            return false;
        }

        public int Login2(M_CUser UL2)
        {
            int type=0;
            foreach (var i in M_CUser.allUsers())
            {
                if (i.name == UL2.name && i.password == UL2.password)
                {
                  if (i.job == "Manager")
                    {
                        type = 1;
                    }
                  if (i.job == "Teacher")
                    {
                        type = 2;
                    }
                  if (i.job == "Receptionist")
                    {
                        type = 3;
                    }
                }
            }
            return type;
        }


        public static List<M_CUser> allUsers()
        {
            string query = "select * from Users;";
            List<M_CUser> Users = new List<M_CUser>();
            Connect.Open();
            SqlCommand command = new SqlCommand(query, Connect);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                M_CUser User = new M_CUser();
                User.name = reader["Name"].ToString();
                User.password = reader["Password"].ToString();
                User.job = reader["Job_Description"].ToString();
                Users.Add(User);
            }
            Connect.Close();

            return Users;
        }



        public static int SingleUser(int UserId)
        {
            string query = "select * from Users where UserId=@UserID";
            Connect.Open();
            SqlCommand command = new SqlCommand(query, Connect);
            command.Parameters.AddWithValue("@UserID", UserId);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            M_CUser MM = new M_CUser();
            MM.name= reader["Name"].ToString();
            MM.job = reader["Job_Description"].ToString();
            Connect.Close();
            return UserId;
        }

        public void addUser(string name,string password,string job)
        {
            string query = "insert into Users values(@name,@Password,@Job_Description)";
            Connect.Open();
            SqlCommand command = new SqlCommand(query, Connect);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@Job_Description", job);
            command.ExecuteNonQuery();
            Connect.Close();
        }

        public void adduser2(string tablename, string[] Attributes, string[] values)
        {
            Connect.Open();
            string query = "insert into ";
            query += tablename + " values";
            query += "(@";
            query += Attributes[0];
            for (int i = 1; i < Attributes.Length; i++)
            {
                query += ",@" + Attributes[i];
            }
            query += ")";

            SqlCommand command = new SqlCommand(query, Connect);
            for (int i = 0; i < Attributes.Length; i++)
            {
                command.Parameters.AddWithValue("@"+Attributes[i], values[i]);
                //MessageBox.Show(Attributes[i] + "," + values[i]);
            }
            command.ExecuteNonQuery();
            Connect.Close();
        }

        public void updateUser(string name, string password , string job , int id)
        {
            //M_Genral.SingleSelect("Users", id, "UserID");
           // M_CUser.SingleUser(id);
            string query = "update Users set Name=@name,Password=@password,Job_Description=@job where UserID=@id";
            Connect.Open();
            SqlCommand command = new SqlCommand(query, Connect);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@job", job);
            command.ExecuteNonQuery();
            Connect.Close();
        }

        public void updateuser2(string tablename, int id, string[] atts, string[] values,string pk)
        {
           // M_Genral.SingleSelect(tablename, id, pk);

            string query = "update " + tablename + " set ";
            for (int i = 0; i < atts.Length; i++)
            {
                if (i < atts.Length - 1)
                {
                    query += atts[i] + "=@" + atts[i] +",";
                }
                else
                {
                    query += atts[i] + "=@" + atts[i];
                }
                //MessageBox.Show(atts[i]);
            }
            query +=  " where "+pk + "=@id";
          //  MessageBox.Show(query);
            
            Connect.Open();
            SqlCommand command = new SqlCommand(query, Connect);
            command.Parameters.AddWithValue("@id", id);
            for (int i = 0; i < atts.Length; i++)
            {
                command.Parameters.AddWithValue(atts[i], values[i]);
            }
            command.ExecuteNonQuery();
            Connect.Close();
            
        }


    }
}
