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
    public partial class employeeMM : Form
    {
       
            SortedDictionary<int, employee> emp = new SortedDictionary<int, employee>();
            SortedDictionary<int, course> emp_courses = new SortedDictionary<int, course>();
            SortedDictionary<int, student> stud = new SortedDictionary<int, student>();
            Dictionary<keeys, attendValues> attend = new Dictionary<keeys, attendValues>();
            user use = new user();
            public employeeMM(user use, SortedDictionary<int, employee> emp, SortedDictionary<int, course> emp_courses, SortedDictionary<int, student> stud, Dictionary<keeys, attendValues> attend)
            {
                InitializeComponent();
                this.use = use;
                this.emp = emp;
                this.emp_courses = emp_courses;
                this.stud = stud;
                this.attend = attend;


            }

            private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            // add course button
            ADDCOURSE course = new ADDCOURSE(use, emp, emp_courses, stud, attend);
            course.Location = new Point((this.Location.X), (this.Location.Y) + 25);
            course.Show();
        }

        private void bunifuGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel10_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            // add student button
            ADDstudent f2 = new ADDstudent(use, emp, emp_courses, stud, attend);
          f2.Location = new Point((this.Location.X), (this.Location.Y) + 25);
            f2.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
        }

        private void main_emp_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            // add attendance button
            Form7 attend1 = new Form7(use, emp, emp_courses, stud, attend);
            attend1.StartPosition = FormStartPosition.Manual;
            attend1.Location = new Point((this.Location.X),(this.Location.Y)+25);
            attend1.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            // report buuton 

           
            

            REPORT1 report1 = new REPORT1(use, emp, emp_courses, stud, attend);
            report1.Location = new Point((this.Location.X), (this.Location.Y) + 25);
            report1.ShowDialog();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f2 = new Form1();
            f2.ShowDialog();
        }
    }
}
