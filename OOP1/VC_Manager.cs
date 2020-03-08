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
    
    public partial class VC_Manager : Form, IObserver
    {
       
        int i = 0;
        
        public VC_Manager()
        { 
            InitializeComponent();
            this.FormClosed += VC_Manager_FormClosed;
            this.FormClosing += VC_Manager_FormClosing;
            this.Load += VC_Manager_Load1;
        }

        private void VC_Manager_Load1(object sender, EventArgs e)
        {
            
        }

        private void VC_Manager_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void VC_Manager_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        public VC_Manager(VC_Kids X, VC_Events Y)
        {
            InitializeComponent();
            this.Activated += VC_Manager_Activated;
            X.AddObserver(this);
            Y.AddObserver(this);
            this.update();
        }

        private void VC_Manager_Activated(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            VC_UsersForm UsersF = new VC_UsersForm();
            UsersF.Show();
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            VC_UtilitesForm UF = new VC_UtilitesForm();
            UF.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] tablenames = { "Buses", "Kids", "Utilites", "Events" };
            VC_Report RR = new VC_Report(tablenames);

            RR.Show();
        }

        private void VC_Manager_Load(object sender, EventArgs e)
        {

        }
        public void update()
        {
            M_Notifications Notif = new M_Notifications();
            Notif.Readfromfile();

            listBox1.Items.Clear();
            for (int i = 0; i < Notif.Nots.Count; i++)
            {
                listBox1.Items.Add(Notif.Nots[i].ToString());
            }
        }
    }
}
