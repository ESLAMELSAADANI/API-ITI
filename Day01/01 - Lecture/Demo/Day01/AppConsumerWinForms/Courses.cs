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
    public partial class frm_Courses : Form
    {
        HttpClient client;
        public frm_Courses()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7179/");
            InitializeComponent();
        }

        private void frm_Courses_Load(object sender, EventArgs e)
        {
            var coursesRes = client.GetAsync("api/course").Result;
            if (coursesRes.IsSuccessStatusCode)
            {
                var courses = coursesRes.Content.ReadAsAsync<List<Course>>().Result;
                dgv_Courses.DataSource = courses;
            }
            var topicsRes = client.GetAsync("api/topic").Result;
            if (topicsRes.IsSuccessStatusCode)
            {
                var topics = topicsRes.Content.ReadAsAsync<List<Topic>>().Result;

                cb_Topic.DataSource = topics;
                cb_Topic.DisplayMember = "topName";
                cb_Topic.ValueMember = "topId";
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Course std = new Course()
            {
                crsId = int.Parse(txt_Id.Text),
                crsName = txt_Name.Text,
                crsDuration = int.Parse(txt_Duration.Text),
                topId = (int) cb_Topic.SelectedValue
            };
            var res = client.PostAsJsonAsync("api/course", std).Result;
            if (res.IsSuccessStatusCode)
            {
                frm_Courses_Load(null, null);
                txt_Id.Text = txt_Name.Text = txt_Duration.Text= "";
                MessageBox.Show("Added Successfully!");
            }
        }
    }
}
