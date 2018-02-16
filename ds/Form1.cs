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
    public partial class Form1 : Form
    {
        SortedDictionary<int, employee> emp = new SortedDictionary<int, employee>();
        SortedDictionary<int, course> emp_courses = new SortedDictionary<int, course>();
        SortedDictionary<int, student> stud = new SortedDictionary<int, student>();
        Dictionary<keeys, attendValues> attend = new Dictionary<keeys, attendValues>();
        user use = new user();
        Boolean status = new Boolean();
        public Form1()
        {


            MYGlobal x = new MYGlobal();
            InitializeComponent();
            emp = x.dataemp();
            emp_courses = x.datacourse();
            stud = x.datastudent();
            attend = x.dataattendance();
            status = false;

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel10_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
                    }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var key1 in stud)
                {
                    if (int.Parse(textBox1.Text) == key1.Key && int.Parse(textBox2.Text) == key1.Value.password)
                    {
                        status = true;
                        use.user_id = key1.Key;
                        MessageBox.Show("login sucsess");
                        this.Hide();
                        Asstudent f2 = new Asstudent(use, emp, emp_courses, stud, attend);
                        f2.ShowDialog();
                        


                        break;

                    }

                }
                if (!status)
                {
                    MessageBox.Show("invalid user name or password");
                }
               
            }
            catch (Exception exep)
            {

                MessageBox.Show(exep.Message);
            }
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
          
        }

        private void bunifuThinButton22_Click_1(object sender, EventArgs e)
        {
            try
            {
                foreach (var key1 in emp)
                {
                    if (key1.Value.name == textBox3.Text && key1.Value.password == Convert.ToInt32(textBox4.Text))
                    {
                        status = true;
                        use.user_id = key1.Key;
                        this.Hide();
                        employeeMM f2 = new employeeMM(use, emp, emp_courses, stud, attend);
                        f2.ShowDialog();
                        


                        break;
                    }

                }
                if (!status)
                {
                    MessageBox.Show("invalid user name or password");
                }
                

            }

            catch (Exception exep)
            {

                MessageBox.Show(exep.Message);
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            warning.Show();
            try
            {

                employee a = new employee();
                int key_ = new int();
                key_ = emp.Keys.Last();
                key_++;
                a.name = textBox5.Text;
                a.password = Convert.ToInt32(textBox6.Text);
                a.Academic_year =textBox7.selectedIndex+1;
                emp.Add(key_, a);
                insertdata(a.name, a.Academic_year, a.password, key_);
                MessageBox.Show("regesteration done ");
                
                
               





            }
            catch (Exception exep)
            {

                MessageBox.Show(exep.Message);
            }
        }

        private void bunifuMaterialTextbox1_OnValueChanged_1(object sender, EventArgs e)
        {
            //login -- student id 
            
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            //login -- student password
        }

        private void login_name_OnValueChanged(object sender, EventArgs e)
        {
            //login -- employee name
        }

        private void login_pass2_OnValueChanged(object sender, EventArgs e)
        {
            //login -- employee password
        }

        private void bunifuMaterialTextbox5_OnValueChanged(object sender, EventArgs e)
        {
            //sign up -- name
        }

        private void bunifuMaterialTextbox6_OnValueChanged(object sender, EventArgs e)
        {
        }

        private void bunifuMaterialTextbox6_OnValueChanged_1(object sender, EventArgs e)
        {
            //sign up -- password
        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
           // sign up -- academic year
        }



        /// <summary>
        /// to insert data into table employees
        /// or add new employee
        /// </summary>
        /// <param name="name"></param>
        /// <param name="Academic_year"></param>
        /// <param name="password"></param>
        /// <param name="ID"></param>
        public void insertdata(string name, int Academic_year, int password, int ID)
        {
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=DSProject;Integrated Security=True");
            connection.Open();
            string insert = @"insert into employees (ID,name,Academic_year,_password) values(@ID,@name,@Academic_year,@password)";
            SqlCommand cmd = new SqlCommand(insert, connection);
            SqlParameter I = new SqlParameter("@ID", ID);
            cmd.Parameters.Add(I);
            SqlParameter na = new SqlParameter("@name", name);
            cmd.Parameters.Add(na);
            SqlParameter Ac = new SqlParameter("@Academic_year", Academic_year);
            cmd.Parameters.Add(Ac);
            SqlParameter pass = new SqlParameter("@password", password);
            cmd.Parameters.Add(pass);
            cmd.ExecuteNonQuery();
            connection.Close();



        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
           
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
    }
}
