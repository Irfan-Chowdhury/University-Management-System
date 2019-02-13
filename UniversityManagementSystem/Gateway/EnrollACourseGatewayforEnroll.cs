using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class EnrollACourseGatewayforEnroll
    {
        public SqlConnection Connection { get; set; }
        public SqlDataReader Reader { get; set; }
        public SqlCommand Command { get; set; }

        public EnrollACourseGatewayforEnroll()
        {
            string connectionString =
                WebConfigurationManager.ConnectionStrings["UniversityDBConString"].ConnectionString;

            Connection = new SqlConnection(connectionString);
        }

        public List<EnrollCourse> GetAllStudentsRegistrationNo()
        {
            string query = "SELECT * FROM RegisterStudent";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<EnrollCourse> students = new List<EnrollCourse>();
            while (Reader.Read())
            {
                EnrollCourse student = new EnrollCourse();
                student.RegNo = Reader["RegNo"].ToString();
                //student.Name = Reader["Name"].ToString();
                students.Add(student);
            }

            Reader.Close();
            Connection.Close();
            return students;
        }

        public List<EnrollCourse> GetStudentByRegNo(string regNo)
        {
            string query = "select r.Name as StudentName,r.Id as StudentId, r.Email as StudentEmail," +
                           "d.DepartmentName as DepartmentName ,d.Id as DepartmentId, c.Id as CourseId," +
                           "c.CourseName as CourseName from RegisterStudent as r " +
                           "full join Department as d " +
                           "on r.DeptId= d.Id " +
                           "full join Course as c " +
                           "on c.DeptId=d.Id where r.RegNo='" + regNo + "'";


            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<EnrollCourse> students = new List<EnrollCourse>();

            while (Reader.Read())
            {
                EnrollCourse student = new EnrollCourse();
                student.StudentName = Reader["StudentName"].ToString();
                student.StudentEmail = Reader["StudentEmail"].ToString();
                student.StudentId = Convert.ToInt32(Reader["StudentId"]);
                student.DepartmentName = Reader["DepartmentName"].ToString();
                string checkCourseId = Reader["CourseId"].ToString();
                if (checkCourseId != "")
                {
                    student.CourseId = Convert.ToInt32(Reader["CourseId"]);
                    student.CourseName = Reader["CourseName"].ToString();
                }
                else
                {
                    student.CourseId = 0;
                    //student.CourseName = null;

                }
                student.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                //student.CourseName = Reader["CourseName"].ToString();
                students.Add(student);
            }

            Reader.Close();
            Connection.Close();
            return students;


        }

        public int SaveEnroll(int studentId, int courseId, string dateValue, int deptId)
        {


            string query = "insert into EnrollACourse(StudentId,CourseId,Date,DeptId) values ('" + studentId + "','" + courseId + "','" + dateValue + "', '" + deptId + "')";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }


        public bool IsEnrollExists(int studentId, int courseId, int deptId)
        {

            string query = "SELECT * FROM EnrollACourse WHERE StudentId ='" + studentId + "' AND CourseId='" + courseId + "' AND DeptId='" + deptId + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();

            return isExists;

        }

    }
}