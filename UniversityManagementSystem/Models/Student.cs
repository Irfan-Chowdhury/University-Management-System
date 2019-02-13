using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
       // public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int GradeId { get; set; }
        public string Date { get; set; }
        public string RegNo { get; set; }
        public int DeptId { get; set; }
        public string Email { get; set; }





    }
}