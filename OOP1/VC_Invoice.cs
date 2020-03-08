using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using OfficeComponent.Pdf;
using OfficeComponent.Pdf.Graphics;

namespace OOP1
{
    public partial class VC_Invoice : Form
    {
        M_Kids MyKidsTopay;
        M_Cstudent Stu;
        int total;
        public VC_Invoice()
        {
            InitializeComponent();
        }

        public VC_Invoice(M_Kids SKidTopay)
        {
            InitializeComponent();
            this.MyKidsTopay = SKidTopay;
            Stu = SKidTopay;
            total += Stu.Fees;
            SetDesign();

        }
        void SetDesign()
        {
            listBox1.Items.Add("Student Id : " + MyKidsTopay.id);
            listBox1.Items.Add("Student Name : " + MyKidsTopay.name);
            listBox1.Items.Add("");
            listBox1.Items.Add("Fees: " + MyKidsTopay.Fees);

        }


        private void VC_Invoice_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddEventToInvoice();
        }

        void AddEventToInvoice()
        {
            if (textBox1.Text != "")
            {
                Stu = new M_Events(Stu);

                Stu = Stu.GetEvent("Events", Int32.Parse(textBox1.Text), "EventID");
                listBox1.Items.Add("Event " + Stu.name + " Fees:" + Stu.Fees.ToString());
                total += Stu.Fees;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddBusToInvoice();
        }

        void AddBusToInvoice()
        {
            if (textBox2.Text != "")
            {
                Stu = new M_Buses(Stu);

                Stu = Stu.GetBus("Buses", Int32.Parse(textBox2.Text), "BusID");
                listBox1.Items.Add("Bus " + Stu.name + " Fees:" + Stu.Fees.ToString());
                total += Stu.Fees;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Total Is: " +total.ToString());
            CreatePdfFile();
            MessageBox.Show("Your Invoice Has been Located in Your Desktop");
            this.Close();

        }

        void CreatePdfFile()
        {
            PdfDocument doc = new PdfDocument();


            PdfPage page = doc.Pages.Add();

            // Create a solid brush
            PdfBrush brush = new PdfSolidBrush(Color.Black);

            const float fontSize = 16.0f;

            // Set the font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, fontSize);

            // Draw the text
            int X = 30;
            int Y = 30;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                page.Graphics.DrawString(listBox1.Items[i].ToString(), font, brush, new PointF(X, Y));
                Y += 30;
            }

            // Save and close the document.
            var outputPath = Path.Combine(@"C:\Users\Zeyad\Desktop", this.GetType().Name + "_" + Guid.NewGuid().ToString() + ".pdf");
            doc.Save(outputPath);
            doc.Close(true);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

