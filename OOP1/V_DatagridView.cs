using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP1
{
    class V_DatagridView : M_ConnSingleton
    {
        private SqlConnection Connect = new SqlConnection("Data Source=ZEYADS-LAPTOP;Initial Catalog=Nursery;Integrated Security=True");
        SqlDataAdapter adapt;

        public void SingleSearch(DataGridView dgv ,string tablename, string UserId, string pk,string type)
        {
            string query;
            type += "ID";
            if (pk == type)
            {
                query = "select * from "; // Users where UserId=@UserID
                query += tablename;
                query += " where ";
                query += pk;
                query += "=";
                query += UserId.ToString();
                //MessageBox.Show(query);
                string query2 = "@" + pk;
            }
            else
            {
                query = "select * from "; // Users where UserId=@UserID
                query += tablename;
                query += " where ";
                query += pk;
                query += "=";
                query += "'" + UserId.ToString();
                query += "'";
               // MessageBox.Show(query);
                string query2 = "@" + pk;
            }
            Connect.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter(query, Connect);
          //  SqlCommand command = new SqlCommand(query,Connect);
            //command.Parameters.AddWithValue(query2, UserId);
            //command.ExecuteNonQuery();
            adapt.Fill(dt);
            dgv.DataSource = dt;
            Connect.Close();
            
        }

            public void DisplayData(DataGridView dgv,string qu)
        {
            Connect.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from "+qu, Connect);
            adapt.Fill(dt);
            dgv.DataSource = dt;
            Connect.Close();
        }

        public DataTable GetReportData(string tablename)
        {
            DataGridView Dgv = new DataGridView();
            Connect.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from " + tablename, Connect);
            adapt.Fill(dt);
            Dgv.DataSource = dt;
            Connect.Close();


            return dt;
        }
    }
}
