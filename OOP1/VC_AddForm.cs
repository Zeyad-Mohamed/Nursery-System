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
    public partial class VC_AddForm : Form
    {
        public List<Label> Labels = new List<Label>();
        public List<TextBox> textboxes = new List<TextBox>();
        DateTimePicker dtp;
        DateTimePicker timePicker;
        string[] atts;
        int Type;
        int id = 0;
        int post = -1;
        int posd = -1;
    
        string Typeofobj;
        public VC_AddForm()
        {
            InitializeComponent();
        }

        public VC_AddForm(string STypeofobj, string textid)
        {
            this.Typeofobj = STypeofobj;
            this.Load += VC_AddForm_Load1;

            //this.id = Int32.Parse(textid);
          
        }

        private void VC_AddForm_Load1(object sender, EventArgs e)
        {
            this.ClientSize = new Size(500, 500);
         
        }

        public void SetDesign(string []Atts,int SType)
        {
            this.Type = SType;
            this.atts = Atts;
            int Y = 40;
            for (int i = 0; i < Atts.Length; i++)
            {
                List<Label> Labels = new List<Label>();
                Label label1 = new Label();
                
                label1.Location = new Point(60, Y);
                label1.Text = Atts[i];
                if( label1.Text == "Birthdate" || label1.Text == "Date")
                {
                    posd = i;
                    Label label2 = new Label();
                    label2.Location = new Point(360, Y);
                    label2.Text = "DD/MM/YY";
                    this.Controls.Add(label2);
                }
                if (label1.Text == "Time")
                {
                    post = i;
                    Label label2 = new Label();
                    label2.Location = new Point(360, Y);
                    label2.Text = "HH:MM";
                    this.Controls.Add(label2);
                }
                label1.AutoSize = true;
              //  label1.Font = new Font("Franklin Gothic",16 , FontStyle.Regular);
                this.Controls.Add(label1);
                Y += 40;
            }
            Y = 40;
            int flag = 0;
            for (int i = 0; i < Atts.Length; i++)
            {
                flag = 0;
                if (i == posd)
                {
                    dtp = new DateTimePicker();
                    dtp.Location = new Point(150, Y);
                    this.Controls.Add(dtp);
                    TextBox Tt = new TextBox();
                    textboxes.Add(Tt);
                    Y += 40;
                    flag=1;
                }


                if (i == post)
                {
                    timePicker = new DateTimePicker();
                    timePicker.ShowUpDown = true;
                    timePicker.Format = DateTimePickerFormat.Custom;
                    timePicker.CustomFormat = "HH:mm"; // Only use hours and minutes
                    
                    timePicker.Location = new Point(150, Y);
                    this.Controls.Add(timePicker);

                    TextBox Tt = new TextBox();
                    textboxes.Add(Tt);
                    Y += 40;
                    flag = 1;
                }
                if (flag == 0)
                {

                    TextBox TBB = new TextBox();
                    TBB.Location = new Point(150, Y);
                    this.Controls.Add(TBB);
                    textboxes.Add(TBB);
                    Y += 40;
                }
                    
                


            }

            Button TheButt = new Button();
            if(this.Type==1)
                TheButt.Text = "Add";
            else
                TheButt.Text = "Update";
            TheButt.Location = new Point(140, Y);
            this.Controls.Add(TheButt);
            TheButt.Click += TheButt_Click;
        }

        private void TheButt_Click(object sender, EventArgs e)
        {
            string[] ss = new string[textboxes.Count];
            int flag2 = 0;
            for (int i = 0; i < textboxes.Count; i++)
            {
                flag2 = 0;
                if ( posd == i)
                {
                    int poss = 0;
                    string X = dtp.Value.Date.ToString();
                    string Y = "";
                    for (int j = 0; j < X.Length; j++)
                    {
                        if (X[j] == ' ')
                        {
                            poss = j;
                            break;
                        }
                    }
                    
                    for(int j=0;j<poss;j++)
                    {
                         Y += X[j];
                        //MessageBox.Show(Y);
                    }

                    ss[i] = Y;
                    flag2 = 1;
                }
                if(post==i)
                {
                    string Z = timePicker.Value.ToString();
                    string C = "";
                    int pos = 0;
                    for (int j = 0; j < Z.Length; j++)
                    {
                        if (Z[j] == ' ')
                        {
                            pos = j;
                            break;
                        }
                    }

                    for (int j = pos+1; j < Z.Length; j++)
                    {
                        C += Z[j];
                        //MessageBox.Show(Y);
                    }
                    ss[i] = C;
                    flag2 = 1;
                }
                if(flag2==0)
                    ss[i] = textboxes[i].Text;
            }

            if(Typeofobj=="Kids" && Type ==1)
                AddKid(ss);
            if (Typeofobj == "Kids" && Type == 0)
                EditKid(ss);
            if (Typeofobj == "Utilities" && Type == 1)
                AddUtility(ss);
            if (Typeofobj == "Utilities" && Type == 0)
                EditUtility(ss);
            if (Typeofobj == "Events" && Type == 1)
                AddEvent(ss);
            if (Typeofobj == "Events" && Type == 0)
                EditEvent(ss);
            if (Typeofobj == "Buses" && Type == 1)
                AddBus(ss);
            if (Typeofobj == "Buses" && Type == 0)
                EditBus(ss);

            this.Close();
        }
        

        // KIDS 
        M_Kids SetKidObj(string []values)
        {
            M_Kids NewKid = new M_Kids();
            NewKid.name = values[0];
            NewKid.birthdate = values[1];
            NewKid.gender = values[2];
            NewKid.address = values[3];
            NewKid.parent_email = values[4];
            NewKid.parent_no = Int32.Parse(values[5]);
            NewKid.fees = values[6];
            return NewKid;
        }
        void AddKid(string []ss)
        {
            M_Kids NewKid = SetKidObj(ss);
            NewKid.MyDBFun.ADD("Kids", this.atts, ss);

            M_Attendance AttKid = new M_Attendance();
            string[] xs = new string[4];
            xs[0] = ss[0];
            xs[1] = ss[6];
            xs[2] = "0";
            xs[3] = "0";
            AttKid.AddKidToAttendance(xs);
            //VC_Manager.mbb.Add("kid Has Been Added");
            M_Notifications.WriteIntoFile("Kid Has Been Added");
            VC_Receptionist.Kidform.NotifyObserver();

        }

        void EditKid(string []ss)
        {
            M_Kids NewKid = SetKidObj(ss);
            NewKid.MyDBFun.updateuser2("Kids",id, this.atts, ss, "KidID");
        }

        // UTILITIES
        M_Utilities SetUtilityObj(string []values)
        {
            M_Utilities NewUtility = new M_Utilities();
            NewUtility.supplier = values[0];
            NewUtility.type = values[1];
            NewUtility.units = Int32.Parse(values[2]);
            NewUtility.price = Int32.Parse(values[3]);
            return NewUtility;
        }
        void AddUtility(string[] ss)
        {
            M_Utilities NewUtil = SetUtilityObj(ss);
            NewUtil.ADD("Utilities", this.atts, ss);
           
        }
        void EditUtility(string[] ss)
        {
            M_Utilities NewUtil = SetUtilityObj(ss);
           NewUtil.updateuser2("Utilities",id, this.atts, ss,"UtilityID");
        }

        // Events
        M_Events SetEventObj(string []values)
        {
            M_Events NewEvent = new M_Events();
            NewEvent.Type = values[0];
            NewEvent.Place = values[1];
            NewEvent.Date = values[2];
            NewEvent.Time = values[3];
            NewEvent.price = Int32.Parse(values[4]);
            return NewEvent;
        }
        void AddEvent(string[] ss)
        {
            M_Events NewEvent = SetEventObj(ss);
            NewEvent.MyDBFun.ADD("Events", this.atts, ss);
            //VC_Manager.mbb.Add("Event Has Been Added");
            M_Notifications.WriteIntoFile("Event Has Been Added");
            VC_Receptionist.eventform.NotifyObserver();
        }
        void EditEvent(string[] ss)
        {
            M_Events NewEvent = SetEventObj(ss);
            NewEvent.MyDBFun.updateuser2("Events", id, this.atts, ss, "EventID");
        }

        // Buses

        M_Buses SetBusObj(string []values)
        {
            M_Buses NewBus = new M_Buses();
            NewBus.Destination = values[0];
            NewBus.Time = Int32.Parse(values[1]);
            NewBus.DriverName = values[2];
            return NewBus;
        }
        void AddBus(string []ss)
        {
            M_Buses NewBus = SetBusObj(ss);
            NewBus.MyDBFun.ADD("Buses", this.atts, ss);
          
        }
        
        void EditBus(string[] ss)
        {
            M_Buses Newbus = SetBusObj(ss);
            Newbus.MyDBFun.updateuser2("Buses", id, this.atts, ss, "BusID");
        }

        private void VC_AddForm_Load(object sender, EventArgs e)
        {

        }
    }
}
 