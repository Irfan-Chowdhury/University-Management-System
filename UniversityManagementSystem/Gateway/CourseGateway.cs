using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class CourseGateway
    {
        public SqlConnection Connection { get; set; }
        public SqlDataReader Reader { get; set; }
        public SqlCommand Command { get; set; }
        public CourseGateway()
        {
            string connectionString =
                WebConfigurationManager.ConnectionStrings["UniversityDBConString"].ConnectionString;

            Connection = new SqlConnection(connectionString);
        }


        public int Save(Course course)
        {
            string query = "INSERT INTO Course VALUES(@CourseCode,@CourseName,@CourseCredit,@CourseDescription,@DeptId,@SemesterId)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@CourseCode", course.CourseCode);
            Command.Parameters.AddWithValue("@CourseName", course.CourseName);
            Command.Parameters.AddWithValue("@CourseCredit", course.CourseCredit);
            Command.Parameters.AddWithValue("@CourseDescription", course.CourseDescription);

            Command.Parameters.AddWithValue("@DeptId", course.DepartmentId);  // change DepartmentId---> DeptId
            Command.Parameters.AddWithValue("@SemesterId", course.SemesterId);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        //************* for Unique of course Name *****************

        public bool IsCourseNameExists(string name)
        {

            string query = "SELECT * FROM Course WHERE CourseName ='" + name + "' ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();

            return isExists;

        }


        //************* for Unique of Course Code *****************

        public bool IsCourseCodeExists(string courseCode) 
        {

            string query = "SELECT * FROM Course WHERE CourseCode ='" + courseCode + "' ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();

            return isExists;

        }




        //********************for Show All Course ***********************

        public List<Course> GetAllCourses()
        {
            string query = "SELECT *FROM Course";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courseList = new List<Course>();
            while (Reader.Read())
            {

                Course course = new Course()
                {
                    Id = Convert.ToInt32(Reader["Id"]),
                    CourseCode = Reader["CourseCode"].ToString(),
                    CourseName = Reader["CourseName"].ToString(),
                    CourseCredit = Convert.ToDecimal(Reader["CourseCredit"]),
                    CourseDescription = Reader["CourseDescription"].ToString(),
                    DepartmentId = Convert.ToInt32(Reader["DeptId"]),  // change DepartmentId---> DeptId
                    SemesterId = Convert.ToInt32(Reader["SemesterId"])

                };
                courseList.Add(course);

            }
            Reader.Close();
            Connection.Close();
            return courseList;
        }





        //****for get CourseByDept.Id downdown List ***********

        public List<Course> GetCoursesByDepartmentId(int departmentId)
        {
            string query = "SELECT *FROM Course WHERE DeptId='" + departmentId + "' ";     // change DepartmentId---> DeptId
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courseList = new List<Course>();
            while (Reader.Read())
            {

                Course course = new Course()
                {
                    Id = Convert.ToInt32(Reader["Id"]),
                    CourseCode = Reader["CourseCode"].ToString(),
                    CourseName = Reader["CourseName"].ToString(),
                    CourseCredit = Convert.ToDecimal(Reader["CourseCredit"]),
                    CourseDescription = Reader["CourseDescription"].ToString(),
                    DepartmentId = Convert.ToInt32(Reader["DeptId"]),       // change DepartmentId---> DeptId
                    SemesterId = Convert.ToInt32(Reader["SemesterId"])
                    
                };
                courseList.Add(course);

            }
            Reader.Close();
            Connection.Close();
            return courseList;
        }




        //********** for Get  CourseDetails By Course.Id ********************

        public Course GetCourseDetailsById(int courseId)  //here courseId=Course.Id , not direct any CourseId  
        {
            string query = "SELECT *FROM Course WHERE Course.Id='" + courseId + "' ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            //List<Course> teacherList = new List<Teacher>();
            Course course = new Course();
            while (Reader.Read())
            {
                course.Id = Convert.ToInt32(Reader["Id"]);
                course.CourseName = Reader["CourseName"].ToString();
                course.CourseCredit = Convert.ToDecimal(Reader["CourseCredit"]);
                break;
            }
            Reader.Close();
            Connection.Close();
            return course;
        }



        //************* for Semester dropdown **************

        public List<Semester> GetSemesterList()
        {
            string query = "SELECT * FROM Semester";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Semester> semesterList = new List<Semester>();
            while (Reader.Read())
            {
                Semester semester = new Semester();
                semester.Id = Convert.ToInt32(Reader["Id"]);
                semester.SemesterName = Reader["SemesterName"].ToString();


                semesterList.Add(semester);

            }
            Reader.Close();
            Connection.Close();
            return semesterList;
        }



        //public int Save(Course course)
        //{
        //    string query = "INSERT INTO Course(CourseCode,CourseName,CourseDescription,DepartmentId,SemesterId) VALUES ('" + course.CourseCode + "','" + course.CourseName + "' ,'" + course.CourseCredit + "' ,'" + course.CourseDescription + "','" + course.DepartmentId + "','" + course.SemesterId + "')";
        //    Command = new SqlCommand(query, Connection);
        //    Connection.Open();
        //    int rowAffect = Command.ExecuteNonQuery();
        //    Connection.Close();
        //    return rowAffect;
        //}
    }
}