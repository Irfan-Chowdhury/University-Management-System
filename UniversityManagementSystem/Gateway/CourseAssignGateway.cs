using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class CourseAssignGateway
    {
        public SqlConnection Connection { get; set; }
        public SqlDataReader Reader { get; set; }
        public SqlCommand Command { get; set; }
        public CourseAssignGateway()
        {
            string connectionString =
                WebConfigurationManager.ConnectionStrings["UniversityDBConString"].ConnectionString;

            Connection = new SqlConnection(connectionString);
        }

        public int AssignCourse(CourseAssignTeacher courseAssignTeacher)
        {
            //string query = "INSERT INTO CourseAssignTeacher VALUES('Assign',@TeacherId,@CourseId)";
            //string query = "INSERT INTO CourseAssignTeacher VALUES('Assign','"+courseAssignTeacher.TeacherId+"','"+courseAssignTeacher.CourseId+"')";

            string query = "INSERT INTO CourseAssignToTeacher VALUES('" + courseAssignTeacher.TeacherId + "','" + courseAssignTeacher.CourseId + "','Assigned')";
            Command = new SqlCommand(query, Connection);            
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }



        //************* for Unique of Course *****************

        public bool IsCourseExists(int courseId)
        {

            //string query = "SELECT * FROM CourseAssignTeacher WHERE CourseId ='" + courseId + "' AND Status = 'Assigned' ";            

            string query = "SELECT * FROM CourseAssignToTeacher WHERE CourseId ='" + courseId + "' AND Status = 'Assigned' ";            
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();

            return isExists;

        }



        //************* for UnAssign Course *****************

        public int UnAssignCourse()
        {
            //string query = "UPDATE CourseAssignTeacher SET Status = 'UnAssign' ";

            string query = "UPDATE CourseAssignToTeacher SET Status = 'Unassigned' ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }



        //************** Teacher Total Credit Taken *****************************

        public decimal GetTotalCreditTaken(int teacherId)
        {
            //string query = "SELECT CourseCredit FROM Course INNER JOIN CourseAssignTeacher ON Course.Id=CourseAssignTeacher.CourseId WHERE TeacherId=" + teacherId+"'and Status='Assign'";
            //string query = "SELECT CourseCredit FROM CourseAssignTeacher INNER JOIN Course ON CourseAssignTeacher.CourseId=Course.Id WHERE Status='Assign' AND TeacherId=" + teacherId;

            string query = "SELECT CourseCredit FROM CourseAssignToTeacher INNER JOIN Course ON CourseAssignToTeacher.CourseId=Course.Id WHERE Status='Assigned' AND TeacherId=" + teacherId;
            Command = new SqlCommand(query, Connection);
            decimal totalTeacherCreaditTaken = 0.0M;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                totalTeacherCreaditTaken += Convert.ToDecimal(Reader["CourseCredit"]);
            }
            Reader.Close();
            Connection.Close();
            return totalTeacherCreaditTaken;
        }




        private int count = 0;

        //************************************** For 6th Story  By Warid *********************************
       
        public List<CourseStaticsViewModel> GetCourseStatitics(string deptName)
        {
            string query = " select c.CourseCode as CourseCode, c.CourseName as CourseName,sem.SemesterName as SemesterName," +
                           " t.TeacherName as TeacherName,cat.Status as Status " +
                           "from Course as c " +
                         "left join CourseAssignToTeacher as cat " +
                           "on c.Id=cat.CourseId " +
                           "left join Teacher as t " +
                           "on cat.TeacherId= t.Id " +
                           "inner join Semester as sem " +
                           "on c.SemesterId= sem.Id" +
                           " inner join Department as d on c.DeptId=d.Id" +
                         " where d.DepartmentName= '" + deptName + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
           

            List<CourseStaticsViewModel> courseStaticsViewModels = new List<CourseStaticsViewModel>();
            while (Reader.Read())
            {
                CourseStaticsViewModel courseStaticsViewModel = new CourseStaticsViewModel();
                courseStaticsViewModel.CourseCode = Reader["CourseCode"].ToString();
                courseStaticsViewModel.CourseName = Reader["CourseName"].ToString();
                courseStaticsViewModel.Semester = Reader["SemesterName"].ToString();
                courseStaticsViewModel.TeacherName = Reader["TeacherName"].ToString();
                courseStaticsViewModel.Status = Reader["Status"].ToString();
                

                if (courseStaticsViewModel.Status == "Unassigned" )
                {

                    courseStaticsViewModel.TeacherName = "Not Assign Yet";

                }
               
                    courseStaticsViewModels.Add(courseStaticsViewModel);
                

            }

            Reader.Close();
            Connection.Close();
            return courseStaticsViewModels;
        }


        public List<CourseStaticsViewModel> GetAllSDepartments()
        {
            string query = "SELECT * FROM Department";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<CourseStaticsViewModel> departments = new List<CourseStaticsViewModel>();
            while (Reader.Read())
            {
                CourseStaticsViewModel department = new CourseStaticsViewModel();
                department.DepartmentName = Reader["DepartmentName"].ToString();

                departments.Add(department);
            }

            Reader.Close();
            Connection.Close();
            return departments;
        }

        //******************************************* End 6th Story *****************************

        
    }
}