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
    public partial class VC_UserAU : Form
    {
        string Type;
        DataGridView DGV;
        string Textid;
        int id;
        public VC_UserAU()
        {
            InitializeComponent();
        }

        public VC_UserAU(string Type,DataGridView dgv, string text,M_CUser X)
        {
            this.Type = Type;
            this.DGV = dgv;
            this.Textid = text;
         //  this.textBox1 = X.name;
            InitializeComponent();

            if(Type=="Add")
            {

                button1.Text = "Add";
                this.Text = "AddUser";
            }
            else
            {
                
               button1.Text = "Update";
               this.Text = "UpdateUser";
            this.id = Int32.Parse(Textid);
            }
        }

        public VC_UserAU(string Type, DataGridView dgv, string text)
        {
            this.Type = Type;
            this.DGV = dgv;
            this.Textid = text;
            //this.textBox1 = X.name;
            InitializeComponent();

            if (Type == "Add")
            {

                button1.Text = "Add";
                this.Text = "AddUser";
            }
            else
            {

                button1.Text = "Update";
                this.Text = "UpdateUser";
                this.id = Int32.Parse(Textid);
            }
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (Type=="Add")
            {
                M_CUser NewUser = new M_CUser();
                NewUser.name = textBox1.Text;
                NewUser.password = textBox2.Text;
                NewUser.job = comboBox1.SelectedItem.ToString();
                bool Check = NewUser.Valid();
                if (Check)
                {
                    string []att = {"Name", "Password", "Job_Description"};
                    string[] val = { NewUser.name, NewUser.password, NewUser.job };
                    //NewUser.addUser(NewUser.name, NewUser.password, NewUser.job);
                    NewUser.adduser2("Users", att, val);


                }
            }
            else
            {
                M_CUser NewUser = new M_CUser();
                NewUser.name = textBox1.Text;
                NewUser.password = textBox2.Text;
                NewUser.job = comboBox1.SelectedItem.ToString();
                // NewUser.updateUser(NewUser.name, NewUser.password, NewUser.job, id);
                string[] atts = { "Name", "Password", "Job_Description" };
                string[] values = { NewUser.name, NewUser.password, NewUser.job };
                //NewUser.updateuser2("Users", id, atts, values,"UserID");
                //NewUser = NewUser.SetTextboxes("Users",Int32.Parse(textBox2.Text),"UserID");
            }
        }
    }
}
