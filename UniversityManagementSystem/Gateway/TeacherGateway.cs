using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class TeacherGateway
    {
        public SqlConnection Connection { get; set; }
        public SqlDataReader Reader { get; set; }
        public SqlCommand Command { get; set; }

        public TeacherGateway()
        {
            string connectionString =
                WebConfigurationManager.ConnectionStrings["UniversityDBConString"].ConnectionString;

            Connection = new SqlConnection(connectionString);
        }

        public int Save(Teacher teacher)
        {
            string query = "INSERT INTO Teacher VALUES(@TeacherName,@Address,@Email,@ContactNo,@DesignationId,@DepartmentId,@CreditToBeTaken)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@TeacherName", teacher.TeacherName);
            Command.Parameters.AddWithValue("@Address", teacher.Address);
            Command.Parameters.AddWithValue("@Email", teacher.Email);
            Command.Parameters.AddWithValue("@ContactNo", teacher.ContactNo);
            Command.Parameters.AddWithValue("@DesignationId", teacher.DesignationId);
            Command.Parameters.AddWithValue("@DepartmentId", teacher.DepartmentId);
            Command.Parameters.AddWithValue("@CreditToBeTaken", teacher.CreditTaken);  //Change CreditTaken(old)--> CreditToBeTaken

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;

        }

        //************* for Unique of Teacher Name *****************

        //public bool IsTeacherNameExists(string teacherName)
        //{

        //    string query = "SELECT * FROM Teacher WHERE TeacherName ='" + teacherName + "' ";
        //    Command = new SqlCommand(query, Connection);
        //    Connection.Open();
        //    Reader = Command.ExecuteReader();
        //    bool isExists = Reader.HasRows;
        //    Connection.Close();

        //    return isExists;

        //}


        //************* for Unique of Teacher Email *****************

        public bool IsTeacherEmailExists(string teacherEmail)
        {

            string query = "SELECT * FROM Teacher WHERE Email ='" + teacherEmail + "' ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();

            return isExists;

        }




        //****for Show All Teachers ***********

        public List<Teacher> GetAllTeachers()
        {
            string query = "SELECT * FROM Teacher";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Teacher> teacherList = new List<Teacher>();
            while (Reader.Read())
            {
                Teacher teacher = new Teacher();
                teacher.Id = Convert.ToInt32(Reader["Id"]);
                teacher.TeacherName = Reader["TeacherName"].ToString();
                teacher.Address = Reader["Address"].ToString();
                teacher.Email = Reader["Email"].ToString();
                teacher.ContactNo = Reader["ContactNo"].ToString();
                teacher.DesignationId = Convert.ToInt32(Reader["DesignationId"]);
                teacher.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);      
                teacher.CreditTaken = Convert.ToDecimal(Reader["CreditToBeTaken"]);  //Change CreditTaken(old)--> CreditToBeTaken

                teacherList.Add(teacher);

            }
            Reader.Close();
            Connection.Close();
            return teacherList;
        }





        //************* for Designation dropdown **************


        public List<Designation> GetDesignationList()
        {
            string query = "SELECT *FROM Designation";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Designation> designationList = new List<Designation>();
            while (Reader.Read())
            {
                Designation designation = new Designation();
                designation.Id = Convert.ToInt32(Reader["Id"]);
                designation.DesignationName = Reader["DesignationName"].ToString();

                designationList.Add(designation);
            }

            Reader.Close();
            Connection.Close();
            return designationList;
        }













        //****for get TeacherbyDept.Id downdown List ***********

        public List<Teacher> GetTeachersByDepartmentId(int departmentId)
        {
            string query = "SELECT *FROM Teacher WHERE DepartmentId='"+departmentId+"' ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Teacher> teacherList = new List<Teacher>();
            while (Reader.Read())
            {
                Teacher teachers = new Teacher();

                teachers.Id = Convert.ToInt32(Reader["Id"]);
                teachers.TeacherName = Reader["TeacherName"].ToString();
                //teachers.Address = Reader["Address"].ToString();
                //teachers.Email = Reader["Email"].ToString();
                //teachers.ContactNo = Reader["ContactNo"].ToString();
                //teachers.DesignationId = Convert.ToInt32(Reader["DesignationId"]);
                //teachers.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                teachers.CreditTaken = Convert.ToDecimal(Reader["CreditToBeTaken"]);  //Change CreditTaken(old)--> CreditToBeTaken
                

                teacherList.Add(teachers);                
            }
            
            Reader.Close();
            Connection.Close();
            return teacherList;
        }



        //****for get TeacherDetails by Teacher.Id***********

        public Teacher GetTeacherDetailsById(int teacherId)  //here teacherId=Teacher.Id , not direct TeacherId  
        {
            string query = "SELECT *FROM Teacher WHERE Teacher.Id='" + teacherId + "' ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader(); 
            List<Teacher> teacherList = new List<Teacher>();
            Teacher teacher  = new Teacher();
            while (Reader.Read())
            {                
                teacher.Id = Convert.ToInt32(Reader["Id"]);
                teacher.TeacherName = Reader["TeacherName"].ToString();
                teacher.CreditTaken = Convert.ToDecimal(Reader["CreditToBeTaken"]);
                break;               
            }
            Reader.Close();
            Connection.Close();
            return teacher;
        }





        ////************************ Total Creit Taken  ***(Transfer in CourseAssignGateway) *********************************************

        //public decimal GetTotalCreditTaken(int teacherId)
        //{
        //    //string query = "SELECT CourseCredit FROM Course INNER JOIN CourseAssignTeacher ON Course.Id=CourseAssignTeacher.CourseId WHERE TeacherId=" + teacherId+"'and Status='Assign'";
        //    string query = "SELECT CourseCredit FROM CourseAssignTeacher INNER JOIN Course ON CourseAssignTeacher.CourseId=Course.Id WHERE Status='Assign' AND TeacherId="+teacherId  ;
        //    Command=new SqlCommand(query,Connection);
        //    decimal totalTeacherCreaditTaken = 0.0M;
        //    Connection.Open();
        //    Reader = Command.ExecuteReader();
        //    while (Reader.Read())
        //    {
        //        totalTeacherCreaditTaken += Convert.ToDecimal(Reader["CourseCredit"]);
        //    }
        //    Reader.Close();
        //    Connection.Close();
        //    return totalTeacherCreaditTaken;
        //}















        ////************* for Teacher dropdown List**************

        //public List<Teacher> GetTeacherList(int departmentId)
        //{
        //    string query = "SELECT Teacher.Id,Teacher.TeacherName FROM Teacher";
        //    Command = new SqlCommand(query, Connection);
        //    Connection.Open();
        //    Reader = Command.ExecuteReader();
        //    List<Teacher> teacherList = new List<Teacher>();
        //    while (Reader.Read())
        //    {
        //        Teacher teacher = new Teacher();
        //        teacher.Id = Convert.ToInt32(Reader["Id"]);
        //        teacher.TeacherName = Reader["TeacherName"].ToString();
        //        teacherList.Add(teacher);

        //    }
        //    Reader.Close();
        //    Connection.Close();
        //    return teacherList;
        //}





       




        

}
}