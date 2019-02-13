using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class CourseAssignTeacher
    {
        public int Id { get; set; }

        public string Status { get; set; }

        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please Select Teacher")]
        public int TeacherId { get; set; }


        //public decimal CreditTaken { get; set; }


        [Required(ErrorMessage = "Please Select Course")]
        public int CourseId { get; set; }

    }
}