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
    public partial class VC_Buses : Form,SAUD
    {
        public VC_Buses()
        {
            InitializeComponent();
            this.Load += VC_Buses_Load;
        }

        private void VC_Buses_Load(object sender, EventArgs e)
        {
            string[] Atts = { "BusID", "Destination", "Time", "Driver_Name", "Fees" };
            for (int i = 0; i < Atts.Length; i++)
            {
                comboBox1.Items.Add(Atts[i]);
            }
            V_DatagridView vdgv = new V_DatagridView();
            vdgv.DisplayData(dataGridView1, "Buses");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add();
        }
        public void Add()
        {
            VC_AddForm AEF = new VC_AddForm("Buses", textBox2.Text);
            string[] Atts = { "Destination", "Time", "Driver_Name", "Fees" };
            AEF.SetDesign(Atts, 1);
            AEF.Show();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewAll();
        }
        public void ViewAll()
        {
            V_DatagridView vdgv = new V_DatagridView();
            vdgv.DisplayData(dataGridView1, "Buses");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Searchh();
        }

        public void Searchh()
        {
            if (textBox5.Text != "" && comboBox1.SelectedItem.ToString() != "")
            {
                string value = textBox5.Text;
                string searchby = comboBox1.SelectedItem.ToString();
                V_DatagridView vv = new V_DatagridView();
                vv.SingleSearch(dataGridView1, "Buses", value, searchby, "Bus");
            }
            else
            {
                MessageBox.Show("Please Enter a Data To Search about it");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete();
        }
        public void Delete()
        {
            if (textBox3.Text != "")
            {
                int id;
                id = Int32.Parse(textBox3.Text);
                M_Buses bu = new M_Buses();
                bu.MyDBFun.Delete("Buses", id, "BusID");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update();
        }
        public void update()
        {
            if (textBox2.Text != "")
            {
                VC_AddForm AEF = new VC_AddForm("Buses", textBox2.Text);
                string[] Atts = { "Destination", "Time", "Driver_Name", "Fees" };
                AEF.SetDesign(Atts, 0);
                AEF.Show();
            }
            else
            {
                MessageBox.Show("Enter ID");
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void VC_Buses_Load_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
