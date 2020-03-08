using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP1
{
    public class M_ConnSingleton
    {
        public static M_ConnSingleton dbInstance;
        public readonly SqlConnection conn = new SqlConnection(@"Data Source=ZEYADS-LAPTOP;Initial Catalog=Nursery;Integrated Security=True");

        public M_ConnSingleton()
        {
        }

        public M_ConnSingleton getDbInstance()
        {
            if (dbInstance == null)
            {
                dbInstance = new M_ConnSingleton();
            }
            return dbInstance;
        }

        public SqlConnection GetDBConnection()
        {
            try
            {
                conn.Open();
              //  MessageBox.Show("Connected");
            }
            catch (SqlException e)
            {
               // MessageBox.Show("Not connected : " + e.ToString());
               // Console.ReadLine();
            }
            finally
            {
                //MessageBox.Show("End..");
                //// Console.WriteLine("Not connected : " + e.ToString());
                //Console.ReadLine();
            }
            Console.ReadLine();
            return conn;
        }

    }
}
