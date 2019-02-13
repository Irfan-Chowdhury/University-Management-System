using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models.ViewModels
{
    public class ClassAndRoomViewModel
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int RoomId { get; set; }
        public string RoomNo { get; set; }
        public string DayName { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public List<string> Schedule { get; set; } 


    }
}