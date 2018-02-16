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
    public partial class REPORT2 : Form
    {
        SortedDictionary<int, employee> emp = new SortedDictionary<int, employee>();
        SortedDictionary<int, course> emp_courses = new SortedDictionary<int, course>();
        SortedDictionary<int, student> stud = new SortedDictionary<int, student>();
        Dictionary<keeys, attendValues> attend = new Dictionary<keeys, attendValues>();
        user use = new user();
        public REPORT2(user use, SortedDictionary<int, employee> emp, SortedDictionary<int, course> emp_courses, SortedDictionary<int, student> stud, Dictionary<keeys, attendValues> attend)
        {
            InitializeComponent();
            this.use = use;
            this.emp = emp;
            this.emp_courses = emp_courses;
            this.stud = stud;
            this.attend = attend;
            fill();

        }

        private void REPORT2_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }
        public void fill()
        {
            int count = new int();
            foreach (var s in attend)
            {
                use.student_id = s.Key.s_id;
                count = 0;
                foreach (var w in attend)
                {
                    if (w.Key.s_id == use.student_id && w.Key.c_id == use.course_id)
                    {
                        if (w.Value.attendance == "No")
                        {
                            count++;
                        }
                    }
                }
                if (count >= 3 && !listBox1.Items.Contains(stud[use.student_id].name))
                {
                    listBox1.Items.Add(stud[use.student_id].name);
                }

            }
        }
    }
}
