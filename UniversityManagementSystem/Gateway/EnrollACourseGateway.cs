using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class EnrollACourseGateway
    {
    
        public SqlConnection Connection { get; set; }
        public SqlDataReader Reader { get; set; }
        public SqlCommand Command { get; set; }

        public EnrollACourseGateway()
        {
            string connectionString =
                WebConfigurationManager.ConnectionStrings["UniversityDBConString"].ConnectionString;

            Connection = new SqlConnection(connectionString);
        }

        public List<Student> GetAllStudentsRegistrationNo()
        {
            string query = "SELECT * FROM RegisterStudent";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<Student> students = new List<Student>();
            while (Reader.Read())
            {
                Student student = new Student();
                student.RegNo = Reader["RegNo"].ToString();
                //student.Name = Reader["Name"].ToString();
                students.Add(student);
            }

            Reader.Close();
            Connection.Close();
            return students;
        }

        public List<SaveResultViewModel> GetCourseByStudentId(int studentid)
        {
            string query = "select c.CourseName as CourseName, c.Id as CourseId from EnrollACourse as e " +
                           "inner join Course as c on e.CourseId= c.Id " +
                           "where e.StudentId= '" + studentid + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<SaveResultViewModel> courses = new List<SaveResultViewModel>();
            while (Reader.Read())
            {
                SaveResultViewModel course = new SaveResultViewModel();
                course.CourseName = Reader["CourseName"].ToString();
                course.CourseId = Convert.ToInt32(Reader["CourseId"]);

                courses.Add(course);
            }

            Reader.Close();
            Connection.Close();
            return courses;


        }

        public List<SaveResultViewModel> GetGrade()
        {
            string query = "select * from Grade";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<SaveResultViewModel> students = new List<SaveResultViewModel>();

            while (Reader.Read())
            {
                SaveResultViewModel student = new SaveResultViewModel();
                student.Grade = Reader["Grade"].ToString();
               
                student.GradeId = Convert.ToInt32(Reader["Id"]);
                students.Add(student);
            }
            Reader.Close();
            Connection.Close();
            return students;

        }



        public int SaveResult(string registrationNo, int courseId, int GradeId)
        {


            string query = "update EnrollACourse set GradeId= '"+GradeId+"' From EnrollACourse " +
                           "inner join RegisterStudent on RegisterStudent.Id= EnrollACourse.StudentId " +
                           "where EnrollACourse.CourseId= '"+courseId+"' and " +
                           "RegisterStudent.RegNo='"+registrationNo+"'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }



        public List<SaveResultViewModel> GetStudentByRegNo(string regNo)
        {
            string query = "select r.Id as StudentId ,r.Name as StudentName, " +
                           "r.Email as StudentEmail, d.DepartmentName as DepartmentName  " +
                           "from RegisterStudent as r inner join Department as d on r.DeptId= d.Id where" +
                           " r.RegNo = '"+regNo+"'";


            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<SaveResultViewModel> students = new List<SaveResultViewModel>();
            
            while (Reader.Read())
            {
                SaveResultViewModel student = new SaveResultViewModel();
                student.StudentName = Reader["StudentName"].ToString();
                student.StudentEmail = Reader["StudentEmail"].ToString();
                student.DepartmentName = Reader["DepartmentName"].ToString();
                student.StudentId = Convert.ToInt32(Reader["StudentId"]);
  
              
                students.Add(student);
            }

            Reader.Close();
            Connection.Close();
            return students;
           
           

        }
    }
}