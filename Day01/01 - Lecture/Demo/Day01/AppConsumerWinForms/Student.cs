using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsumerWinForms
{
    public class Student
    {
        public int stId { get; set; }
        public string stFname { get; set; }
        public string stLname { get; set; }
        public string stAddress { get; set; }
        public int? stAge { get; set; }
        public int? deptId { get; set; }
        public int? stSuper { get; set; }
    }
}
