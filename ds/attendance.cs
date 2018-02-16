using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ds
{
    public partial class attendance : Form
    {
        SortedDictionary<int, employee> emp = new SortedDictionary<int, employee>();
        SortedDictionary<int, course> emp_courses = new SortedDictionary<int, course>();
        SortedDictionary<int, student> stud = new SortedDictionary<int, student>();
        Dictionary<keeys, attendValues> attend = new Dictionary<keeys, attendValues>();
        user use = new user();
        public attendance(user use, SortedDictionary<int, employee> emp, SortedDictionary<int, course> emp_courses, SortedDictionary<int, student> stud, Dictionary<keeys, attendValues> attend)
        {
            InitializeComponent();
            this.use = use;
            this.emp = emp;
            this.emp_courses = emp_courses;
            this.stud = stud;
            this.attend = attend;
            students();
            //=====================================
            int date = new int();
            date = 0;
            foreach (var s in attend)
            {
                if (use.course_id == s.Key.c_id)
                {
                    if (date < s.Key.week)
                    {
                        date = s.Key.week;
                    }
                }

            }
            date++;


            label3.Text = "Attendance of Lecture " + date + " ";
            //=================================================

        }
        public void students()
        {
            int Ayear = emp_courses[use.course_id].Academic_year;
            foreach (var n in stud)
            {
                if (Ayear == n.Value.Academic_year)
                {
                    listBox1.Items.Add(n.Value.name);
                }
            }

        }
        private void attendance_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.Text;
            foreach (var x in stud)
            {
                if (listBox1.Text == x.Value.name)
                {
                    use.student_id = x.Key;
                }
            }

            textBox2.Text = use.student_id.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int date = new int();
            date = 0;
            keeys ky = new keeys();
            attendValues val = new attendValues();
            foreach (var s in attend)
            {
                if (use.student_id == s.Key.s_id && use.course_id == s.Key.c_id)
                {
                    if (date < s.Key.week)
                    {
                        date = s.Key.week;
                    }
                }

            }
            date++;
            ky.c_id = use.course_id;
            ky.s_id = use.student_id;
            ky.week = date;

            if (comboBox1.selectedIndex == 0)
                val.attendance = "Yes";
            else
                val.attendance = "No";

            val.e_id = use.user_id;
            attend.Add(ky, val);
            insertdata(ky.s_id, ky.c_id, val.e_id, ky.week, val.attendance);


        }

        private void comboBox1_onItemSelected(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel10_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void insertdata(int S_ID, int C_ID, int Emp_Id, int week,string  _status)
        {
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=DSProject;Integrated Security=True");
            connection.Open();
            string insert = @"insert into Attendance (S_ID,C_ID,Emp_Id,week,_status) values(@S_ID,@C_ID,@Emp_Id,@week,@_status)";
            SqlCommand cmd = new SqlCommand(insert, connection);
            SqlParameter I = new SqlParameter("@S_ID", S_ID);
            cmd.Parameters.Add(I);
            SqlParameter I1 = new SqlParameter("@C_ID", C_ID);
            cmd.Parameters.Add(I1);
            SqlParameter EI = new SqlParameter("@Emp_Id", Emp_Id);
            cmd.Parameters.Add(EI);
            SqlParameter wk = new SqlParameter("@week", week);
            cmd.Parameters.Add(wk);
            SqlParameter st = new SqlParameter("@_status", _status);
            cmd.Parameters.Add(st);

            cmd.ExecuteNonQuery();
            connection.Close();



        }

    }
}
