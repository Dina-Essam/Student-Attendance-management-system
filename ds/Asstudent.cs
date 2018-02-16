using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ds
{
    public partial class Asstudent : Form
    {
        SortedDictionary<int, employee> emp = new SortedDictionary<int, employee>();
        SortedDictionary<int, course> emp_courses = new SortedDictionary<int, course>();
        SortedDictionary<int, student> stud = new SortedDictionary<int, student>();
        Dictionary<keeys, attendValues> attend = new Dictionary<keeys, attendValues>();
        user use = new user();
        // function 1
        public Asstudent(user use, SortedDictionary<int, employee> emp, SortedDictionary<int, course> emp_courses, SortedDictionary<int, student> stud, Dictionary<keeys, attendValues> attend)
        {
            InitializeComponent();
            this.use = use;
            this.emp = emp;
            this.emp_courses = emp_courses;
            this.stud = stud;
            this.attend = attend;
            academic_year();

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel26_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f2 = new Form1();
            f2.ShowDialog();
            // log out button 
        }

        private void bunifuCustomLabel5_Click_1(object sender, EventArgs e)
        {
            // student's name 
        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {
            // student's id 
        }

        private void bunifuCustomLabel3_Click_1(object sender, EventArgs e)
        {
            // number of absent 
        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {
            // name 
        }

        private void bunifuCustomLabel1_Click_1(object sender, EventArgs e)
        {
            // id
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {
            // number of absence 
        }

        private void bunifuGradientPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = new int();
            count = 0;
            foreach (var c in emp_courses)
            {
                if (listBox1.Text == c.Value.name)
                {
                    use.course_id = c.Key;
                }
            }



            foreach (var s in attend)
            {

                if (use.user_id == s.Key.s_id && use.course_id == s.Key.c_id)
                {
                    if (s.Value.attendance == "No")
                    {
                        count++;
                    }
                }

            }


            textBox3.Text = count.ToString();
            textBox1.Text = stud[use.user_id].name;
            textBox2.Text = use.user_id.ToString();


            // list box to show courses' names 
        }

        private void bunifuGradientPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
        public void academic_year()
        {
            int Ayear = stud[use.user_id].Academic_year;
            foreach (var name in emp_courses)
            {
                if (Ayear == name.Value.Academic_year)
                {
                    listBox1.Items.Add(name.Value.name);
                }
            }

        }
    }
}
