using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class EnrollCourse
    {
        [Required]
        public string RegNo { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentEmail { get; set; }
        [Required]
        public string DepartmentName { get; set; }
       [Required]
        public string CourseName { get; set; }
        [Required]
        public string CourseCode { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public int StudentId { get; set; }
    }
}