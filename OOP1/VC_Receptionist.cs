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
    public partial class VC_Receptionist : Form
    {
        public static VC_Kids Kidform = new VC_Kids();
        public static VC_Events eventform = new VC_Events();
        public VC_Receptionist()
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            this.Text = "Receptionaist";
        }

        private void Receptionist_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VC_Kids kidform = new VC_Kids();
            kidform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VC_Events eventform = new VC_Events();
            eventform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VC_Buses busesform = new VC_Buses();
            busesform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            M_Kids Temp = new M_Kids();
            Temp = Temp.getKid("Kids", Int32.Parse(textBox1.Text), "KidID");
            VC_Invoice Invo = new VC_Invoice(Temp);
            Invo.Show();
        }
    }
}
