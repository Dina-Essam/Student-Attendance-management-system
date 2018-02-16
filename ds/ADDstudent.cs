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
    public partial class ADDstudent : Form
    {
        SortedDictionary<int, employee> emp = new SortedDictionary<int, employee>();
        SortedDictionary<int, course> emp_courses = new SortedDictionary<int, course>();
        SortedDictionary<int, student> stud = new SortedDictionary<int, student>();
        Dictionary<keeys, attendValues> attend = new Dictionary<keeys, attendValues>();
        user use = new user();
        public ADDstudent(user use, SortedDictionary<int, employee> emp, SortedDictionary<int, course> emp_courses, SortedDictionary<int, student> stud, Dictionary<keeys, attendValues> attend)
        {
            InitializeComponent();
            this.use = use;
            this.emp = emp;
            this.emp_courses = emp_courses;
            this.stud = stud;
            this.attend = attend;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // adding information
                student salamony = new student();
                salamony.name = textBox1.Text;
                salamony.password = int.Parse(textBox4.Text);
                salamony.Academic_year = comboBox1.selectedIndex+1;
                stud.Add(int.Parse(textBox2.Text), salamony);
                Addstudent(salamony.name, Convert.ToInt32(textBox2.Text), salamony.password, salamony.Academic_year);
                MessageBox.Show("Added :) ");
                textBox1.Text = " ";
                textBox2.Text = " ";
                textBox4.Text = " ";
                comboBox1.Clear();
                // from this form to another one
                this.Hide();

            }
            catch (Exception exep)
            {

                MessageBox.Show(exep.Message);
            }

        }
        public void Addstudent(string name, int ID, int _password, int Academic_year)
        {
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=DSProject;Integrated Security=True");
            connection.Open();
            string command = @"insert into student(name,ID,_password,Academic_year) values(@name,@ID,@_password,@Academic_year)";
            SqlCommand cmd = new SqlCommand(command, connection);
            SqlParameter na = new SqlParameter("@name", name);
            cmd.Parameters.Add(na);
            SqlParameter I = new SqlParameter("@ID", ID);
            cmd.Parameters.Add(I);
            SqlParameter pass = new SqlParameter("@_password", _password);
            cmd.Parameters.Add(pass);
            SqlParameter Aca = new SqlParameter("@Academic_year", Academic_year);
            cmd.Parameters.Add(Aca);
            cmd.ExecuteNonQuery();
            connection.Close();


        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.Text = " ";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            this.Text = " ";
        }

        private void textBox4_OnValueChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            this.Text = " ";
        }

        private void ADDstudent_Load(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_onItemSelected(object sender, EventArgs e)
        {

        }

        private void add_course_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
