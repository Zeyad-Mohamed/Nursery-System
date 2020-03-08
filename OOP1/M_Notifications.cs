using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace OOP1
{
    public class M_Notifications
    {
        string path = @"Notifaction.txt";
        public List<string> Nots = new List<string>();
        public void Readfromfile()
        {
            using (StreamReader sr = File.OpenText(this.path))
            {
                String s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    string pnn;
                    pnn = s;
                    Nots.Add(pnn);
                }
                sr.Close();
            }

        }

        public static void WriteIntoFile(string Note)
        {
            string path = @"Notifaction.txt";
            using (StreamWriter sr = File.AppendText(path))
            {
                sr.WriteLine(Note);
            }
        }
    }
}
