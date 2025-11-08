using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AppConsumerWinForms
{
    public partial class frm_Students : Form
    {
        HttpClient client;
        public frm_Students()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7179/");

            InitializeComponent();
        }

        private void frm_Students_Load(object sender, EventArgs e)
        {
            var response = client.GetAsync("api/student").Result;
            if (response.IsSuccessStatusCode)
            {
                var students = response.Content.ReadAsAsync<List<Student>>().Result;
                dgv_Students.DataSource = students;
            }
            var deptsRes = client.GetAsync("api/department").Result;
            var supervisorsRes = client.GetAsync("api/student").Result;
            if (deptsRes.IsSuccessStatusCode)
            {
                var depts = deptsRes.Content.ReadAsAsync<List<Department>>().Result;
                var supervisors = supervisorsRes.Content.ReadAsAsync<List<Student>>().Result;
                cb_Dept.DataSource = depts;
                cb_Dept.DisplayMember = "deptName";
                cb_Dept.ValueMember = "deptId";

                cb_Supervisor.DataSource = supervisors;
                cb_Supervisor.DisplayMember = "stFname";
                cb_Supervisor.ValueMember = "stId";
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Student std = new Student()
            {
                stId = int.Parse(txt_Id.Text),
                stFname = txt_fName.Text,
                stLname = txt_lName.Text,
                stAddress = txt_Address.Text,
                stAge = int.Parse(txt_Age.Text),
                deptId = (int)cb_Dept.SelectedValue,
                stSuper = (int)cb_Supervisor.SelectedValue
            };
            var res = client.PostAsJsonAsync("api/student", std).Result;
            if (res.IsSuccessStatusCode)
            {
                frm_Students_Load(null, null);
                txt_Address.Text = txt_Id.Text = txt_Age.Text = txt_fName.Text = txt_lName.Text = "";
                MessageBox.Show("Added Successfully!");
            }
        }
    }
}
