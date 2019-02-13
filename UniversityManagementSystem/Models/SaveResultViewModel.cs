using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class SaveResultViewModel
    {
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string DepartmentName { get; set; }
        public string CourseName { get; set; }
        public int CourseId { get; set; }

        public string Grade { get; set; }
        public int GradeId { get; set; }
        public string Message { get; set; }
        public int StudentId { get; set; }
    }
}