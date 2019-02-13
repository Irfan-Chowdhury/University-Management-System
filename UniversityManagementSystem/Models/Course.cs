using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide Course Code")]
        [Display(Name = "Course Code")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Course Code must be at least 5 characters long")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "Please provide Course Name")]
        [Display(Name = "Course Name")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Course Name must be 2 to 30 character long")]
        public string CourseName { get; set; }

        [Required]
        [Display(Name = "Credit")]
        [Range(0.5, 5.0, ErrorMessage = "Credit must be within 0.5 to 5.0")]
        public decimal CourseCredit { get; set; }

        [Required]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string CourseDescription { get; set; }

        [Required(ErrorMessage = "Please Select Department")]
        [Display(Name = "Department")]
        public int  DepartmentId { get; set; }

        [Required(ErrorMessage = "Please Select Semester")]
        [Display(Name = "Semester")]
        public int  SemesterId { get; set; }
        
        public int DeptId { get; set; }  //------for Pias
        
    }
}