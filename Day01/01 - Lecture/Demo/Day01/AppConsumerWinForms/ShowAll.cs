using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppConsumerWinForms
{
    public partial class frm_ShowAll : Form
    {
        public frm_ShowAll()
        {
            InitializeComponent();
        }

        private void btn_Students_Click(object sender, EventArgs e)
        {
            new frm_Students().Show();
        }

        private void btn_Courses_Click(object sender, EventArgs e)
        {
            new frm_Courses().Show();
        }
    }
}
