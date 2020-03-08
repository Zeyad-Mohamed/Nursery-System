using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
   public  class M_Buses : M_Service
    {
        M_Cstudent Stu;

        public M_Genral MyDBFun = new M_Genral();

        public int BusID { get; set; }
        public string Destination { get; set; }
        public int Time { get; set; }
        public string DriverName { get; set; }
        public M_Buses()
        {

        }
        public M_Buses(M_Cstudent SStu)
        {
            this.Stu = SStu;
        }

    }
}
