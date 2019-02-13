using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class DepartmentGateway
    {
        public SqlConnection Connection { get; set; }
        public SqlDataReader Reader { get; set; }
        public SqlCommand Command { get; set; }
        public DepartmentGateway()
        {
            string connectionString =
                WebConfigurationManager.ConnectionStrings["UniversityDBConString"].ConnectionString;

            Connection = new SqlConnection(connectionString);
        }

        public int Save(Department department)
        {
            string query = "INSERT INTO Department VALUES(@DepartmentCode,@DepartmentName)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@DepartmentCode", department.DepartmentCode);
            Command.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }



        //************* for Unique of department Name *****************

        public bool IsDepartmentNameExists(string name)
        {

            string query = "SELECT * FROM Department WHERE DepartmentName ='" + name + "' ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();

            return isExists;

        }

        //************* for Unique of Department Code *****************

        public bool IsDepartmentCodeExists(string code)
        {

            string query = "SELECT * FROM Department WHERE DepartmentCode ='" + code + "' ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();

            return isExists;

        }


        //public int Save(Department department)
        //{
        //    string query = "INSERT INTO Department(Code,Name) VALUES ('" + department.Code + "','" + department.Name + "')";
        //    Command = new SqlCommand(query, Connection);
        //    Connection.Open();
        //    int rowAffect = Command.ExecuteNonQuery();
        //    Connection.Close();
        //    return rowAffect;
        //}



        //****for Show All Department ***********

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



        //****for get Department downdown List ***********

        //public List<Department> GetDepartmentList()
        //{
        //    string query = "SELECT Department.Id,Department.DepartmentName FROM Department";
        //    Command = new SqlCommand(query, Connection);
        //    Connection.Open();
        //    Reader = Command.ExecuteReader();
        //    List<Department> departmentList = new List<Department>();
        //    while (Reader.Read())
        //    {

        //        Department department = new Department()
        //        {
        //            Id = Convert.ToInt32(Reader["Id"]),
        //            //Code = Reader["Code"].ToString(),
        //            DepartmentName = Reader["DepartmentName"].ToString()
        //        };
        //        departmentList.Add(department);

        //    }
        //    Reader.Close();
        //    Connection.Close();
        //    return departmentList;
        //}









        public Department FindById(int id)
        {
            string query = "SELECT * FROM Department WHERE Id=" + id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Department department = new Department()
            {
                Id = Convert.ToInt32(Reader["Id"]),
                DepartmentCode = Reader["DepartmentCode"].ToString(),
                DepartmentName = Reader["DepartmentName"].ToString(),
                
            };
            Connection.Close();
            return department;
        }
    }
}