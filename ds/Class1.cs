using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ds
{
    public class user
    {
        public int user_id;
        public int course_id;
        public int student_id;
    }

    //-----------------------------------------------------------------------------------------------------------------
    public class employee
    {
        public string name;
        public int Academic_year;
        public int password;
    }
    //-----------------------------------------------------------------------------------------------------------------
    public class course
    {
        public string name;
        public string dr_name;
        public int Academic_year;
    }

    //-----------------------------------------------------------------------------------------------------------------
    public class student
    {
        public string name;
        public int password;
        public int Academic_year;

    }
    //-------------------------------------------------------------------------------------------------------------------------------------------------
    public class keeys
    {
        public int s_id;
        public int c_id;
        public int week;

    }

    public class attendValues
    {
        public int e_id;
        public string attendance;
    }

    //-----------------------------------------------------------------------------------------------------------------


    class MYGlobal
    {

        SortedDictionary<int, employee> emp = new SortedDictionary<int, employee>();
        SortedDictionary<int, course> emp_courses = new SortedDictionary<int, course>();
        SortedDictionary<int, student> stud = new SortedDictionary<int, student>();
        Dictionary<keeys, attendValues> attend = new Dictionary<keeys, attendValues>();

        //-------------------------------------------------------------------------------------------------------------------------------------------------
        public SortedDictionary<int, employee> dataemp()
        {

            SqlConnection con1 = new SqlConnection("Data Source =.; Initial Catalog = DSProject; Integrated Security = True");
            con1.Open();
            SqlDataAdapter read = new SqlDataAdapter("select * from employees ", con1);
            DataTable dt = new DataTable();
            read.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                employee zft = new employee();
                zft.name = dr["name"].ToString();
                zft.Academic_year = (int)dr["Academic_year"];
                zft.password = (int)dr["_password"];
                emp.Add((int)dr["ID"], zft);
            }

            con1.Close();
            return emp;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------

        public SortedDictionary<int, course> datacourse()
        {

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DSProject;Integrated Security=True");
            con.Open();
            SqlDataAdapter reader1 = new SqlDataAdapter("select * from course ", con);
            DataTable dt = new DataTable();
            reader1.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                course cor = new course();
                cor.name = (string)dr["name"];
                cor.Academic_year = (int)dr["Academic_year"];
                cor.dr_name = (string)dr["Dr_name"];
                emp_courses.Add((int)dr["ID"], cor);
            }


            con.Close();
            return emp_courses;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------
        public SortedDictionary<int, student> datastudent()
        {

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DSProject;Integrated Security=True");
            con.Open();
            SqlDataAdapter reader2 = new SqlDataAdapter("select * from student ", con);
            DataTable dt = new DataTable();
            reader2.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                student taleb = new student();
                taleb.name = (string)dr["name"];
                taleb.password = (int)dr["_password"];
                taleb.Academic_year = (int)dr["Academic_year"];
                stud.Add((int)dr["ID"], taleb);
            }

            con.Close();
            return stud;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------
        public Dictionary<keeys, attendValues> dataattendance()
        {

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DSProject;Integrated Security=True");
            con.Open();
            SqlDataAdapter reader3 = new SqlDataAdapter("select * from Attendance ", con);
            DataTable dt = new DataTable();
            reader3.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                keeys key1 = new keeys();
                attendValues value1 = new attendValues();
                key1.c_id = (int)dr["C_ID"];
                key1.s_id = (int)dr["S_ID"];
                key1.week = (int)dr["week"];
                value1.attendance = (string)dr["_status"];
                value1.e_id = (int)dr["Emp_Id"];
                attend.Add(key1, value1);
            }
            con.Close();

            return attend;
        }




    }
}
