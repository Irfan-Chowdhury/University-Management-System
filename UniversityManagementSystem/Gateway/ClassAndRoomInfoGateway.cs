using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.Models.ViewModels;

namespace UniversityManagementSystem.Gateway
{
    public class ClassAndRoomInfoGateway
    {
        SqlConnection Connection { get; set; }
        SqlCommand Command { get; set; }
        SqlDataReader Reader { get; set; }

        public ClassAndRoomInfoGateway()
        {
            string connectionstring = WebConfigurationManager.ConnectionStrings["UniversityDBConString"].ConnectionString;
            Connection = new SqlConnection(connectionstring);
        }

        //***************************Class And Room By Department**********************************

        public List<ClassAndRoomViewModel> GetClassAndRoomByDeptId(int departmentId)
        {
            string query = "Select c.CourseCode,c.CourseName,r.RoomNo,d.DayName,cr.FromTime,cr.ToTime " +
                           "From Course As c Inner join Department AS dp ON c.DeptId = dp.Id " +
                           "INNER JOIN  ClassRoomAllocate As cr ON c.Id = cr.CourseId " +
                           "Inner join Room AS r ON cr.RoomId = r.Id " +
                           "Inner join Day AS d ON cr.DayId =d.Id Where c.DeptId=@departmentId";
            Command = new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@departmentId",departmentId);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ClassAndRoomViewModel> classAndRoomViewModels = new List<ClassAndRoomViewModel>();
            while (Reader.Read())
            {
                ClassAndRoomViewModel classAndRoom = new ClassAndRoomViewModel();
                classAndRoom.CourseCode = Reader["CourseCode"].ToString();
                classAndRoom.CourseName = Reader["CourseName"].ToString();
                classAndRoom.RoomNo = Reader["RoomNo"].ToString();
                classAndRoom.DayName = Reader["DayName"].ToString();
                classAndRoom.FromTime = Reader["FromTime"].ToString();
                classAndRoom.ToTime = Reader["ToTime"].ToString();
                //classAndRoom.Schedule = Reader["Schedule"].ToString();
                classAndRoomViewModels.Add(classAndRoom);
            }
            Reader.Close();
            Connection.Close();
            return classAndRoomViewModels;
        }
    }
}