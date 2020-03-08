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
    public partial class VC_UtilitesForm : Form,SAUD
    {
        public VC_UtilitesForm()
        {
            InitializeComponent();
            this.Text = "Utilities";
            this.Load += VC_UtilitesForm_Load;
        }

        private void VC_UtilitesForm_Load(object sender, EventArgs e)
        {
            string[] Atts = {"UtilityID","Supplier", "Type", "Units", "Price" };
            for (int i = 0; i < Atts.Length; i++)
            {
                comboBox1.Items.Add(Atts[i]);
            }
            V_DatagridView vdg = new V_DatagridView();
            vdg.DisplayData(dataGridView1, "Utilities");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void Search_Click(object sender, EventArgs e)
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
                vv.SingleSearch(dataGridView1, "Utilities", value, searchby, "Utility");
            }
            else
            {
                MessageBox.Show("Please Enter a Data To Search about it");
            }
        }

        private void VC_UtilitesForm_Load_1(object sender, EventArgs e)
        {

        }

        public void Add()
        {
            VC_AddForm AUF = new VC_AddForm("Utilities", textBox2.Text);
            string[] Atts = { "Supplier", "Type", "Units", "Price" };
            AUF.SetDesign(Atts, 1);
            AUF.Show();
        }

        public void Delete()
        {
            if (textBox3.Text != "")
            {
                int id;
                id = Int32.Parse(textBox3.Text);
                M_Utilities ut = new M_Utilities();
                ut.Delete("Utilities", id, "UtilityID");
            }
            else
            {
                MessageBox.Show("Enter ID");
            }
        }

        public void ViewAll()
        {
            V_DatagridView vdg = new V_DatagridView();
            vdg.DisplayData(dataGridView1, "Utilities");
        }

        public void update()
        {
            if (textBox2.Text != "")
            {
                VC_AddForm AUF = new VC_AddForm("Utilities", textBox2.Text);
                string[] Atts = { "Supplier", "Type", "Units", "Price" };
                AUF.SetDesign(Atts, 0);
                AUF.Show();
            }
        }

 
    }
}
