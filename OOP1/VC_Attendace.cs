using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP1
{
    public partial class VC_Attendace : Form
    {
        V_DatagridView VV;
        public VC_Attendace()
        {
            InitializeComponent();
            ViewData();
        }

        private void VC_Attendace_Load(object sender, EventArgs e)
        {
            string[] Atts = { "KidIDA", "Name", "ClassNo", "Present", "Absent" };
            for (int i = 0; i < Atts.Length; i++)
            {
                comboBox1.Items.Add(Atts[i]);
            }
            ViewData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Present();


        }

        void ViewData()
        {
            VV = new V_DatagridView();
            VV.DisplayData(dataGridView1, "AttendanceQ");

        }

        void Present()
        {
            int id = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            int noofpres = Int32.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            noofpres++;
            M_Attendance AttKid = new M_Attendance();
            string[] atts = { "Present" };
            string no = noofpres.ToString();
            string[] values = { no };
            AttKid.updateuser2("AttendanceQ", id, atts, values, "KidID");
            ViewData();


        }

        void Absent()
        {
            int id = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            int noofpres = Int32.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            noofpres++;
            M_Attendance AttKid = new M_Attendance();
            string[] atts = { "Absent" };
            string no = noofpres.ToString();
            string[] values = { no };
            AttKid.updateuser2("AttendanceQ", id, atts, values, "KidID");
            ViewData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Absent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != null && comboBox1.SelectedItem.ToString() != null)
            {
                string value = textBox5.Text;
                string searchby = comboBox1.SelectedItem.ToString();
                V_DatagridView vv = new V_DatagridView();
                vv.SingleSearch(dataGridView1, "AttendanceQ", value, searchby, "KidID");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
