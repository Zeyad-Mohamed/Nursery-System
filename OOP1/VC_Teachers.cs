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
    public partial class VC_Teachers : Form
    {
        public VC_Teachers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TakeAttendance();
        }

        void TakeAttendance()
        {
            VC_Attendace att = new VC_Attendace();

            att.Show();
        }
    }
}
