using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class RegisterStudentGateway
    {
        public SqlConnection Connection { get; set; }


        public SqlDataReader Reader { get; set; }
        public SqlCommand Command { get; set; }

        public RegisterStudentGateway()
        {

            string connectionString =
                WebConfigurationManager.ConnectionStrings["UniversityDBConString"].ConnectionString;
            Connection = new SqlConnection(connectionString);
            
        }

        public int Save(Register register)
        {
            //string query = "INSERT INTO RegisterStudent(Name,Email,ContactNo,Date,Address,DeptId) VALUES(@name,@email,@contactNo,@date,@address,@deptId) ";
            string query = "INSERT INTO RegisterStudent VALUES(@name,@email,@contactNo,@date,@address,@deptId,@regNo) ";
            //string query = "INSERT INTO RegisterStudent VALUES(@regNo,@email,@contactNo,@date,@address,@deptId,@name) ";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@name", register.Name);
            //Command.Parameters.AddWithValue("@regNo", register.RegNo);
            Command.Parameters.AddWithValue("@email", register.Email);
            Command.Parameters.AddWithValue("@contactNo", register.ContactNo);
            Command.Parameters.AddWithValue("@date", register.Date);
            Command.Parameters.AddWithValue("@address", register.Address);
            Command.Parameters.AddWithValue("@deptId", register.DeptId);
            Command.Parameters.AddWithValue("@regNo", register.RegNo);
            //Command.Parameters.AddWithValue("@name", register.Name);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsEmailExists(string Email)
        {

            string query = "SELECT * FROM RegisterStudent WHERE Email ='" + Email + "' ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            
            bool IsExists = Reader.HasRows;
            Connection.Close();

            return IsExists;

        }

        //****for get Department dropdownList ***********

        public List<Department> GetDepartmentList()
        {
            string query = "SELECT Department.Id as DeptId,Department.DepartmentName as DepartmentName FROM Department";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Department> departmentList = new List<Department>();
            while (Reader.Read())
            {

                Department department = new Department()
                {
                    Id = Convert.ToInt32(Reader["DeptId"]),
                  
                    DepartmentName = Reader["DepartmentName"].ToString()
                };
                departmentList.Add(department);

            }
            Reader.Close();
            Connection.Close();
            return departmentList;
          
        }


	//**************for getting dept code**********************

        public string GetDepartmentCodeById(int departmentId)
        {
            //string query = "SELECT Department.Id as DeptId,Department.DepartmentCode as DepartmentCode FROM Department";
            string query = "Select DepartmentCode from Department where Id = '" + departmentId+ "'";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            string departmentCode = null;
            while (Reader.Read())
            {
                departmentCode = Reader["DepartmentCode"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return departmentCode;

        }

        public int GetStudentId(Register register)
        {
            string query = "Select * from RegisterStudent where Email = '"+register.Email+"'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            int studentId = Convert.ToInt32(Reader["Id"]);
            Reader.Close();
            Connection.Close();
            return studentId;

        }

        public int GetStudentSerial(Register register)
        {
            string query = "SELECT COUNT(RegNo) FROM RegisterStudent where RegNo Like '" + register.RegNo + "%'";
           
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int count =(int) Command.ExecuteScalar();
            Reader.Close();
            Connection.Close();
            return count;
        }

        public int finalRegNo(Register register)
        {
            string query = "update RegisterStudent set RegNo ='" + register.RegNo + "' where Id='" + register.StudentId +
                           "'";
            Command= new SqlCommand(query,Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }






        //************* for Show Department copied from Department Gateway **********

        public List<Department> GetAllDepartments()
        {
            string query = "SELECT * FROM Department";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Department> departmentList = new List<Department>();
            while (Reader.Read())
            {
                Department department = new Department();
                department.Id = Convert.ToInt32(Reader["Id"]);
                department.DepartmentCode = Reader["DepartmentCode"].ToString();
                department.DepartmentName = Reader["DepartmentName"].ToString();

                departmentList.Add(department);

            }
            Reader.Close();
            Connection.Close();
            return departmentList;
        }



        
    }
}