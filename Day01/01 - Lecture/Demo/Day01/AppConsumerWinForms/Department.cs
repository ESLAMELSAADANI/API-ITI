using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsumerWinForms
{
    public class Department
    {
        public int deptId { get; set; }

        public string deptName { get; set; }

        public string deptDesc { get; set; }

        public string deptLocation { get; set; }

        public int? deptManager { get; set; }

        public DateOnly? managerHiredate { get; set; }
    }
}
