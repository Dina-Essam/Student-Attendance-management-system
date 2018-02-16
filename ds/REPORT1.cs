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
    public partial class REPORT1 : Form
    {
        SortedDictionary<int, employee> emp = new SortedDictionary<int, employee>();
        SortedDictionary<int, course> emp_courses = new SortedDictionary<int, course>();
        SortedDictionary<int, student> stud = new SortedDictionary<int, student>();
        Dictionary<keeys, attendValues> attend = new Dictionary<keeys, attendValues>();
        user use = new user();
        public REPORT1(user use, SortedDictionary<int, employee> emp, SortedDictionary<int, course> emp_courses, SortedDictionary<int, student> stud, Dictionary<keeys, attendValues> attend)
        {
            InitializeComponent();
            this.use = use;
            this.emp = emp;
            this.emp_courses = emp_courses;
            this.stud = stud;
            this.attend = attend;
            academic_year();


        }
        public void academic_year()
        {
            int Ayear = emp[use.user_id].Academic_year;
            foreach (var name in emp_courses)
            {
                if (Ayear == name.Value.Academic_year)
                {
                    listBox1.Items.Add(name.Value.name);
                }
            }

        }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (var c in emp_courses)
            {
                if (listBox1.Text == c.Value.name)
                {
                    use.course_id = c.Key;
                }
            }


            this.Hide();
            REPORT2 h2 = new REPORT2(use, emp, emp_courses, stud, attend);
            h2.Location = new Point((this.Location.X), (this.Location.Y) + 25);
            h2.ShowDialog();
        }
    }
}
