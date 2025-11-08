using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsumerWinForms
{
    public class Course
    {
        public int crsId { get; set; }

        public string crsName { get; set; }

        public int? crsDuration { get; set; }

        public int? topId { get; set; }
    }
}
