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
    public partial class VC_UsersForm : Form, SAUD
    {
        M_Genral MyDBFun = new M_Genral();
        public VC_UsersForm()
        {
            InitializeComponent();
            this.Load += VC_UsersForm_Load1;
        }

        private void VC_UsersForm_Load1(object sender, EventArgs e)
        {
            string[] Atts = { "UserID","Name","Password","Job_Description"};
            for (int i = 0; i < Atts.Length; i++)
            {
                comboBox1.Items.Add(Atts[i]);
            }
            V_DatagridView VV = new V_DatagridView();
            VV.DisplayData(dataGridView1, "Users");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewAll();        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Searchh();
        }

        private void VC_UsersForm_Load(object sender, EventArgs e)
        {

        }

        public void Add()
        {

            VC_UserAU AddU = new VC_UserAU("Add", dataGridView1, textBox2.Text);
            AddU.Show();
        }

        public void update()
        {
            M_CUser NewUser = new M_CUser();
           // NewUser = NewUser.SetTextboxes("Users", Int32.Parse(textBox2.Text), "UserID");
            if (textBox2.Text != "")
            {
                VC_UserAU UpdateU = new VC_UserAU("Update", dataGridView1, textBox2.Text,NewUser);
                UpdateU.Show();
            }
            else
            {
                MessageBox.Show("Enter ID");
            }
        }

        public void Delete()
        {
            int id;

            id = Int32.Parse(textBox3.Text);
            this.MyDBFun.Delete("Users", id, "UserID");
        }

        public void ViewAll()
        {
            V_DatagridView VV = new V_DatagridView();
            VV.DisplayData(dataGridView1, "Users");
        }

        public void Searchh()
        {
            if (textBox5.Text != "" && comboBox1.SelectedItem.ToString() != "")
            {
                string value = textBox5.Text;
                string searchby = comboBox1.SelectedItem.ToString();
                V_DatagridView vv = new V_DatagridView();
                vv.SingleSearch(dataGridView1, "Users", value, searchby, "User");
            }
            else
            {
                MessageBox.Show("Please Enter a Data To Search about it");
            }
        }
    }
}
