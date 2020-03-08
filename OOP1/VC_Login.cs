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
    public partial class Login : Form
    {
        public static VC_Manager MN = new VC_Manager(VC_Receptionist.Kidform, VC_Receptionist.eventform);
        int type;
        VC_Teachers TC;
        VC_Receptionist RC;
        public Login()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            M_CUser UU = new M_CUser();
            UU.name = textBox1.Text;
            UU.password = textBox2.Text;

            if (textBox1.Text != "" && textBox2.Text != "")
            {

                if (UU.Login(UU))
                {
                    ///
                    type = UU.Login2(UU);

                    if (type == 1)
                    {
                        Login.MN = new VC_Manager(VC_Receptionist.Kidform, VC_Receptionist.eventform);
                        Login.MN.Show();
                    }
                    if (type == 2)
                    {
                         TC = new VC_Teachers();
                        TC.Show();
                    }
                    if (type == 3)
                    {
                         RC = new VC_Receptionist();
                        RC.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Enter Correct Username Or password");
            }
        }
    }
}
