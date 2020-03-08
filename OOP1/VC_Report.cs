using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Spire.Pdf;

//using OfficeComponent.Pdf.Graphics;
//using OfficeComponent.Pdf;
//using PdfFileWriter;
using Spire.Pdf.Tables;
using Spire.Pdf.Graphics;

namespace OOP1
{
    public partial class VC_Report : Form
    {
        string[] tablenames;
        List<Label> Labels;
        DataGridView dgv1 = new DataGridView();
        public VC_Report()
        {
            InitializeComponent();
        }

        public VC_Report(string []STablesnames)
        {
            InitializeComponent();
            SetTableNames(STablesnames);
            
        }

        void SetTableNames(string []STablesnames)
        {
            this.tablenames = new string[STablesnames.Length];
            for (int i=0;i<STablesnames.Length;i++)
            {
                this.tablenames[i] = STablesnames[i];
            }
            SetDesign();
        }

        void SetDesign()
        {
            int Y = 0;
            Labels = new List<Label>();
            Label label1 = new Label();

            label1.Location = new Point(260, Y);
            label1.Text = "Suggestions: ";
            label1.AutoSize = true;
            label1.Font = new Font("Franklin Gothic",14 , FontStyle.Regular);
            this.Controls.Add(label1);
            Y += 30;
            for (int i =0;i<this.tablenames.Length;i++)
            {
                
               label1 = new Label();

                label1.Location = new Point(265, Y);
                label1.Text = "-" + this.tablenames[i];
                label1.AutoSize = true;
                //  label1.Font = new Font("Franklin Gothic",16 , FontStyle.Regular);
                this.Controls.Add(label1);
                Y += 20;
            }
        }

        void SetPdf()
        {
            Getit();
            //create a pdf document  
            PdfDocument pdf = new PdfDocument();
            //add a page  
            PdfPageBase page = pdf.Pages.Add();
            PdfPageBase page2 = pdf.Pages.Add();


            //create a table  
            PdfTable table = new PdfTable() ;

            //export datagridview to table  
            table.DataSource = dgv1.DataSource;

            //show header  
            table.Style.ShowHeader = true;

            //set cell padding  
            table.Style.CellPadding = 2;
            

           
            //draw table to pdf page  
            table.Draw(page, new RectangleF(10, 50, 450, 300));
            PdfFont font = new PdfFont(PdfFontFamily.TimesRoman, 10f);
            
            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);


            page.Canvas.DrawString("Number of " + textBox1.Text+" in Nursery is "+ table.Rows.Count, font, brush, new PointF(50, 200));


           // pdf.SaveToFile(@"C:\Users\Zeyad\Desktop\Output.pdf");
            MessageBox.Show("Your Report Has been located on your desktop");
            this.Close();
            var outputPath = Path.Combine(@"C:\Users\Zeyad\Desktop", this.GetType().Name + "_" + Guid.NewGuid().ToString() + ".pdf");
            pdf.SaveToFile(outputPath);
        }

 

 

        private void VC_Report_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetPdf();

        }

        void Getit()
        {
            string tablename = textBox1.Text;
            this.dgv1 = new DataGridView();
            V_DatagridView vdgv = new V_DatagridView();
            this.dgv1.DataSource = vdgv.GetReportData(tablename);
        }
    }
}
