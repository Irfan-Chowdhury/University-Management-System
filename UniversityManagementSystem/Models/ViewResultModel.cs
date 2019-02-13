using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class ViewResultModel
    {
        public string RegNo { get; set; }
        
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string DepartmentName { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        
        public string Grade { get; set; }
        public int GradeId { get; set; }
        public string Message { get; set; }
        public int StudentId { get; set; }
    }
}