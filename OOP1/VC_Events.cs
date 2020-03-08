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
    public partial class VC_Events : Form,ISubject,SAUD
    {
        public List<IObserver> observers;
        public VC_Events()
        {
            InitializeComponent();
            observers = new List<IObserver>();
            this.Load += VC_Events_Load1;
        }

        private void VC_Events_Load1(object sender, EventArgs e)
        {
            string[] Atts = { "EventID","Type", "Place", "Date", "Time", "Price" };
            for (int i=0;i<Atts.Length;i++)
            {
                comboBox1.Items.Add(Atts[i]);
            }
            V_DatagridView vdgv = new V_DatagridView();
            vdgv.DisplayData(dataGridView1, "Events");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewAll();
        }

        private void VC_Events_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete();
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

        private void button4_Click(object sender, EventArgs e)
        {
            SearchEvent();
        }

        void SearchEvent()
        {
            if (textBox5.Text != "" && comboBox1.SelectedItem.ToString() != "")
            {
                string value = textBox5.Text;
                string searchby = comboBox1.SelectedItem.ToString();
                V_DatagridView vv = new V_DatagridView();
                vv.SingleSearch(dataGridView1, "Events", value, searchby, "Event");
            }
            else
            {
                MessageBox.Show("Please Enter a Data To Search about it");
            }
        }

        public void Add()
        {
            VC_AddForm AEF = new VC_AddForm("Events", textBox2.Text);
            string[] Atts = { "Type", "Place", "Date", "Time", "Price" };
            AEF.SetDesign(Atts, 1);
            AEF.Show();
        }

        public void update()
        {
            if (textBox2.Text != "")
            {
                VC_AddForm AEF = new VC_AddForm("Events", textBox2.Text);
                string[] Atts = { "Type", "Place", "Date", "Time", "Price" };
                AEF.SetDesign(Atts, 0);
                AEF.Show();
            }
            else
            {
                MessageBox.Show("Enter ID");
            }
        }

        public void Delete()
        {
            if (textBox3.Text != "")
            {
                int id;
                id = Int32.Parse(textBox3.Text);
                M_Events ev = new M_Events();
                ev.MyDBFun.Delete("Events", id, "EventID");
            }
        }

        public void ViewAll()
        {
            V_DatagridView vdgv = new V_DatagridView();
            vdgv.DisplayData(dataGridView1, "Events");
        }

        public void Searchh()
        {
            throw new NotImplementedException();
        }
    }
}
