using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    public class M_Service : M_Cstudent
    {
        M_Cstudent stu;
        public int price { get; set; }

        public override int Cost()
        {
            return 0;
        }
    }
}
