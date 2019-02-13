using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class EnrollACourseGatewayforResult
    {
        public SqlConnection Connection { get; set; }
        public SqlDataReader Reader { get; set; }
        public SqlCommand Command { get; set; }

        public EnrollACourseGatewayforResult()
        {
            string connectionString =
                WebConfigurationManager.ConnectionStrings["UniversityDBConString"].ConnectionString;

            Connection = new SqlConnection(connectionString);
        }

        public List<ViewResultModel> GetAllStudentsRegistrationNo()
        {
            string query = "SELECT * FROM RegisterStudent";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<ViewResultModel> students = new List<ViewResultModel>();
            while (Reader.Read())
            {
                ViewResultModel student = new ViewResultModel();
                student.RegNo = Reader["RegNo"].ToString();
                //student.Name = Reader["Name"].ToString();
                students.Add(student);
            }

            Reader.Close();
            Connection.Close();
            return students;
        }



        public List<ViewResultModel> GetStudentByRegNo(string regNo)
        {
            string query = "select r.Name as StudentName, r.Email as StudentEmail," +
                           " d.DepartmentName as DepartmentName, c.CourseName as CourseName  ," +
                           " c.CourseCode as CourseCode , g.Grade as Grade" +
                           " from RegisterStudent as r inner join Department as d on r.DeptId= d.Id inner join " +
                           "EnrollACourse as e on r.Id= e.StudentId" +
                           " inner join Course as c on c.Id = e.CourseId" +
                           " left join Grade as g on g.Id= e.GradeId" +
                           " where r.RegNo='" + regNo + "'";


            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ViewResultModel> students = new List<ViewResultModel>();

            while (Reader.Read())
            {
                ViewResultModel student = new ViewResultModel();
                student.StudentName = Reader["StudentName"].ToString();
                student.StudentEmail = Reader["StudentEmail"].ToString();
                student.DepartmentName = Reader["DepartmentName"].ToString();
                student.CourseCode = Reader["CourseCode"].ToString();
                student.CourseName = Reader["CourseName"].ToString();
                student.Grade = Reader["Grade"].ToString();

                students.Add(student);
            }

            Reader.Close();
            Connection.Close();
            return students;


        }
    }
}