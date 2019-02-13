using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Models.ViewModels;

namespace UniversityManagementSystem.Gateway
{
    public class ClassRoomAllocationGateway
    {
        SqlConnection Connection { get; set; }
        SqlCommand Command { get; set; }
        SqlDataReader Reader { get; set; }

        public ClassRoomAllocationGateway()
        {
            string connectionstring = WebConfigurationManager.ConnectionStrings["UniversityDBConString"].ConnectionString;
            Connection = new SqlConnection(connectionstring);
        }

        //*************************************Allocate Classroom *****************************
        public int Allocate(ClassRoomAllocate classRoomAllocate)
        {
            //string query = "INSERT INTO ClassRoomAllocate VALUES(@DeptId,@CourseId,@RoomId,@DayId,@FromTime,@ToTime,@Status)";
            string query = "INSERT INTO ClassRoomAllocate VALUES(@DeptId,@CourseId,@RoomId,@DayId,@FromTime,@ToTime,@Status)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@DeptId", classRoomAllocate.DeptId);
            Command.Parameters.AddWithValue("@CourseId", classRoomAllocate.CourseId);
            Command.Parameters.AddWithValue("@RoomId", classRoomAllocate.RoomId);
            Command.Parameters.AddWithValue("@DayId", classRoomAllocate.DayId);
            Command.Parameters.AddWithValue("@FromTime", classRoomAllocate.FromTime);
            Command.Parameters.AddWithValue("@ToTime", classRoomAllocate.ToTime);
            Command.Parameters.AddWithValue("@Status", classRoomAllocate.Status = "Allocated");

            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffect;
        }


        //**************** Shedule Uniqe *******************************
        public bool IsSheduleTimeExists(ClassRoomAllocate classRoomAllocate)
        {

            string query = "SELECT * FROM ClassRoomAllocate WHERE RoomId='"+classRoomAllocate.RoomId+"'AND DayId='" + classRoomAllocate.DayId + "' AND FromTime ='" + classRoomAllocate.FromTime + "' AND ToTime='" + classRoomAllocate.ToTime + "' AND Status='Allocated' ";
            //string query = "SELECT * FROM ClassRoomAllocate FromTime BETWEEN '" + classRoomAllocate.FromTime + "' AND ToTime='" + classRoomAllocate.ToTime + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();

            return isExists;

        }
        

        //public List<DepartmentViewModel> GetDepartmentByDepartmentId(int departmentId)
        //{
        //    string query = "Select * From DepartmentView WHERE DepartmentId=@departmentId";
        //    Command = new SqlCommand(query, Connection);
        //    Command.Parameters.AddWithValue("departmentId", departmentId);
        //    List<DepartmentViewModel> departments = new List<DepartmentViewModel>(); 

        //    Connection.Open();
        //    Reader = Command.ExecuteReader();
        //    if (Reader.Read())
        //    {
        //        Department department = new Department();
        //        department.Id = Convert.ToInt32(Reader["Id"]);
        //        department.DepartmentCode = Reader["DepartmentCode"].ToString();
        //        department.DepartmentName = Reader["DepartmentName"].ToString();
                
        //    }
        //    Connection.Close();
        //    return departments;
        //}


        //***********************DEPARTMENT DROPDOWN*********************************

        public List<Department> GetAllDepartments()
        {
            string query = "SELECT * FROM Department";
            Command = new SqlCommand(query,Connection);
            List<Department> departments = new List<Department>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Department department = new Department();
                department.Id = Convert.ToInt32(Reader["Id"]);
                department.DepartmentName = Reader["DepartmentName"].ToString();
                department.DepartmentCode = Reader["DepartmentCode"].ToString();
                departments.Add(department);
                
            }
            Reader.Close(); 
            Connection.Close();
            return departments;
        }

        //***********************COURSE DROPDOWN*********************************

        public List<DepartmentViewModel> GetCourseByDepartmentId(int departmentId)
        {
            string query = "Select * From DepartmentView WHERE DeptId=@departmentId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("departmentId", departmentId);
            List<DepartmentViewModel> departments = new List<DepartmentViewModel>();

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                DepartmentViewModel department = new DepartmentViewModel();
                department.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                // department.DepartmentCode = Reader["DepartmentCode"].ToString();
                department.DepartmentName = Reader["DepartmentName"].ToString();
                department.CourseId = Convert.ToInt32(Reader["CourseId"]);
                //department.CourseCode = Reader["CourseCode"].ToString();
                department.CourseName = Reader["CourseName"].ToString();
                // department.CourseCredit = Reader["CourseCredit"].ToString();
                // department.CourseDescription = Reader["CourseDescription"].ToString();
                department.DeptId = Convert.ToInt32(Reader["DeptId"]);
                // department.SemesterId = Convert.ToInt32(Reader["SemesterId"]);
                departments.Add(department);
            }
            Connection.Close();
            return departments;
        }
        public List<Course> GetAllCourses()
        {
            string query = "SELECT * FROM Course";
            Command = new SqlCommand(query, Connection);
            List<Course> courses = new List<Course>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Course course = new Course();
                course.Id = Convert.ToInt32(Reader["Id"]);
                course.CourseName = Reader["CourseName"].ToString();
                course.CourseCode = Reader["CourseCode"].ToString();
                //course.CourseCredit = Reader["CourseCredit"].ToString();
                course.CourseCredit = Convert.ToDecimal(Reader["CourseCredit"]);
                course.CourseDescription = Reader["CourseDescription"].ToString();
                course.DeptId = Convert.ToInt32(Reader["DeptId"]);
                course.SemesterId = Convert.ToInt32(Reader["SemesterId"]);
                courses.Add(course);

            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        //***********************Room DROPDOWN*********************************


        public List<Room> GetAllRooms()
        {
            string query = "SELECT * FROM Room";
            Command = new SqlCommand(query, Connection);
            List<Room> rooms = new List<Room>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Room room = new Room();
                room.Id = Convert.ToInt32(Reader["Id"]);
                room.RoomNo = Reader["RoomNo"].ToString();
                
                rooms.Add(room);

            }
            Reader.Close();
            Connection.Close();
            return rooms;
        }

        //***********************DAY DROPDOWN*********************************

        public List<Day> GetAllDay()
        {
            string query = "SELECT * FROM Day";
            Command = new SqlCommand(query, Connection);
            List<Day> days = new List<Day>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Day day = new Day();
                day.Id = Convert.ToInt32(Reader["Id"]);
                day.DayName = Reader["DayName"].ToString();

                days.Add(day);

            }
            Reader.Close();
            Connection.Close();
            return days;
        }
      

        //**********************  Unallocated All ClassRoom **********************

        public int UnallocateClassRooms() 
        {
            //string query = "UPDATE CourseAssignTeacher SET Status = 'UnAssign' ";

            string query = "UPDATE ClassRoomAllocate SET Status = 'Unallocated' ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close(); 
            return rowAffect;
        }



    }
}