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
    public partial class VC_Kids : Form,ISubject,SAUD
    {
        public List<IObserver> observers;
        public VC_Kids()
        {
            InitializeComponent();
            this.Text = "kids";
            observers = new List<IObserver>();
            this.Load += VC_Kids_Load1;
        }

        private void VC_Kids_Load1(object sender, EventArgs e)
        {
            string[] Atts = {"KidID", "Name", "Birthdate", "Gender", "Address", "Parent_Email", "Phone_Number", "ClassNo", "Fees" };
            for (int i = 0; i < Atts.Length; i++)
            {
                comboBox1.Items.Add(Atts[i]);
            }
            V_DatagridView vdgv = new V_DatagridView();
            vdgv.DisplayData(dataGridView1, "Kids");
        }

        private void VC_Kids_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add();
        }

        public void Add()
        {
            VC_AddForm AKF = new VC_AddForm("Kids", textBox2.Text);
            string[] Atts = { "Name", "Birthdate", "Gender", "Address", "Parent_Email", "Phone_Number", "ClassNo", "Fees" };
            AKF.SetDesign(Atts, 1);
            AKF.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update();
        }

        public void update()
        {
            if (textBox2.Text != "")
            {
                VC_AddForm AKF = new VC_AddForm("Kids", textBox2.Text);
                string[] Atts = { "Name", "Birthdate", "Gender", "Address", "Parent_Email", "Phone_Number", "ClassNo", "Fees" };
                AKF.SetDesign(Atts, 0);
                AKF.Show();
            }
            else
            {
                MessageBox.Show("Enter ID");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            ViewAll();
        }

        public void ViewAll()
        {
            V_DatagridView vdgv = new V_DatagridView();
            vdgv.DisplayData(dataGridView1, "Kids");
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
                M_Kids kd = new M_Kids();
                kd.MyDBFun.Delete("Kids", id, "KidID");
            }
            else
            {
                MessageBox.Show("Enter ID");
            }
        }

        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void NotifyObserver()
        {

            foreach (var observer in observers)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Searchh();
        }

        public void Searchh()
        {
            if (textBox1.Text != "" && comboBox1.SelectedItem.ToString() != "")
            {
                string value = textBox1.Text;
                string searchby = comboBox1.SelectedItem.ToString();
                V_DatagridView vv = new V_DatagridView();
                vv.SingleSearch(dataGridView1, "Kids", value, searchby, "Kid");
            }
            else
            {
                MessageBox.Show("Please Enter a Data To Search about it");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
