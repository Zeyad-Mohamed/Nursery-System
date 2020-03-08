using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace OOP1
{
    public class M_Kids : M_Cstudent, ISubject
    {
        public M_Genral MyDBFun = new M_Genral();
        public string birthdate { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string parent_email { get; set; }
        public int parent_no { get; set; }

        public string fees { get; set; }

        public List<IObserver> observers;

        public M_Kids()
            {
            observers = new List<IObserver>();
            }

        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void NotifyObserver()
        {
           
           foreach(var observer in observers)
            {
                observer.update();
            }

        }

        public void RemoveObserver(IObserver o)
        {
            int i = observers.IndexOf(o);
            if (i >= 0)
            {
                observers.RemoveAt(i);
            }
        }

        public void KidsChanged()
        {
            NotifyObserver();
        }

        public M_Kids getKid(string tablename, int UserId, string pk)
        {

            string query = "select * from "; // Users where UserId=@UserID
            query += tablename;
            query += " where ";
            query += pk;
            query += "=@";
            query += pk;
            //MessageBox.Show(query);
            string query2 = "@" + pk;
            M_Genral.Connect.Open();
            SqlCommand command = new SqlCommand(query, M_Genral.Connect);
            command.Parameters.AddWithValue(query2, UserId);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            M_Kids KidTopay = new M_Kids();
            KidTopay.id = Int32.Parse(reader["KidID"].ToString());
            KidTopay.name = reader["Name"].ToString();
            KidTopay.Fees = Int32.Parse(reader["Fees"].ToString());

            /*  M_CUser MM = new M_CUser();
              MM.name = reader["Name"].ToString();
              MM.job = reader["Job_Description"].ToString();*/

            string fees = reader["Fees"].ToString();

            M_Genral.Connect.Close();
            return KidTopay;
        }




        

        public override int Cost()
        {
            throw new NotImplementedException();
        }
    }
}
