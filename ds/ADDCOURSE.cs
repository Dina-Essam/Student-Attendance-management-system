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
    public partial class ADDCOURSE : Form
    {

        SortedDictionary<int, employee> emp = new SortedDictionary<int, employee>();
        SortedDictionary<int, course> emp_courses = new SortedDictionary<int, course>();
        SortedDictionary<int, student> stud = new SortedDictionary<int, student>();
        Dictionary<keeys, attendValues> attend = new Dictionary<keeys, attendValues>();
        user use = new user();
        public ADDCOURSE(user use, SortedDictionary<int, employee> emp, SortedDictionary<int, course> emp_courses, SortedDictionary<int, student> stud, Dictionary<keeys, attendValues> attend)
        {
            InitializeComponent();
            this.use = use;
            this.emp = emp;
            this.emp_courses = emp_courses;
            this.stud = stud;
            this.attend = attend;


        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //adding information
            int key = new int();
            key = emp_courses.Keys.Last() + 1;
            course barmaga = new course();
            barmaga.name = textBox1.Text;
            barmaga.dr_name = textBox2.Text;
            barmaga.Academic_year =comboBox1.selectedIndex+1;
            emp_courses.Add(key, barmaga);
            addcource(key, barmaga.name, barmaga.Academic_year, barmaga.dr_name);
            MessageBox.Show("Added Course");
            textBox1.Text = " ";
            textBox2.Text = " ";


            // from this form to another form 
            this.Hide();
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void add_course_Paint(object sender, PaintEventArgs e)
        {

        }

        public void addcource(int ID, string name, int Academic_year, string Dr_name)
        {
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=DSProject;Integrated Security=True");
            connection.Open();
            string insert = @"insert into course (ID,name,Academic_year,Dr_name) values(@ID,@name,@Academic_year,@Dr_name)";
            SqlCommand cmd = new SqlCommand(insert, connection);
            SqlParameter I = new SqlParameter("@ID", ID);
            cmd.Parameters.Add(I);
            SqlParameter na = new SqlParameter("@name", name);
            cmd.Parameters.Add(na);
            SqlParameter Ac = new SqlParameter("@Academic_year", Academic_year);
            cmd.Parameters.Add(Ac);
            SqlParameter pass = new SqlParameter("@Dr_name", Dr_name);
            cmd.Parameters.Add(pass);
            cmd.ExecuteNonQuery();
            connection.Close();





        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
        }

        private void textBox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = " ";
           

        }
    }
}
