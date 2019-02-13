using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models.ViewModels
{
    public class DepartmentViewModel
    {
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentCode { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        [Required]
        [Display(Name = "Course Name  ")]
        public int CourseId { get; set; }
        [Required]
        public string CourseCode { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string CourseCredit { get; set; }
        [Required]
        public string CourseDescription { get; set; }
        [Required]
        [Display(Name = "Department Name  ")]
        public int DeptId { get; set; }
        [Required]
        public int SemesterId { get; set; }
        [Required]
        [Display(Name = "Room No  ")]
        public int RoomId { get; set; }
        [Required]
        public string RoomNo { get; set; }
        [Required]
        [Display(Name = "Day Name  ")]
        public int DayId { get; set; }
        [Required]
        public string DayName { get; set; }
        [Required]
        [Display(Name = "From  ")]
        public string FromTime { get; set; }
        [Required]
        [Display(Name = "To  ")]
        public string ToTime { get; set; }
    }
}