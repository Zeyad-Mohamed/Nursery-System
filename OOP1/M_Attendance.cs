using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace OOP1
{
    class M_Attendance : M_Genral
    {
        public int id { get; set; }
        public string name { get; set; }
        public int ClassNo { get; set; }
        public int Present { get; set; }
        public int Absent { get; set; }

       // public SqlConnection Connect = new SqlConnection("Data Source=DESKTOP-70BI87A;Initial Catalog=Nursery;Integrated Security=True");


        public void AddKidToAttendance(string []values)
        {
            string []atts = { "Name", "ClassNo" };
            string query = "insert into AttendanceQ values(@Name,@ClassNo,@Present,@Absent)";
            int x = 0;
            //Connect.Open();
            SqlCommand command = new SqlCommand(query, GetDBConnection());
            command.Parameters.AddWithValue("@Name", values[0]);
            command.Parameters.AddWithValue("@ClassNo", values[1]);
            command.Parameters.AddWithValue("@Present",x);
            command.Parameters.AddWithValue("@Absent", x);
            command.ExecuteNonQuery();
            //Connect.Close();
        }
        public void ReadKidsNames(int classNo)
        {
           
        }


    }
}
