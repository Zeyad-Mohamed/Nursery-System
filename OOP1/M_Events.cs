using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    public class M_Events : M_Service
    {
        M_Cstudent Stu;

        public M_Genral MyDBFun = new M_Genral();
        public string Type { get; set; }
        public string Place { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
       
        public M_Events()
        {
            
        }

        public M_Events(M_Cstudent SStu)
        {
            this.Stu = SStu;
        }



    }
}
