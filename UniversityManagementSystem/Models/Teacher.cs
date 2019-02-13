using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide Teacher Name")]
        [Display(Name = "Teacher Name")]
        //[StringLength(20, MinimumLength = 2, ErrorMessage = "Teacher Name must be 2 to 20 character long")]
        public string TeacherName { get; set; }

        [Required(ErrorMessage = "Please provide Adreess")]
        public string Address { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please provide Correct Email")]
        public string Email { get; set; }

        [Required]
        public string ContactNo { get; set; }

        [Display(Name = "Designation")]
        [Required]
        public int DesignationId { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }

        [Required]
        [Range(0.5, 15.0, ErrorMessage = "Credit must be within 0.5 to 15.0")]
        public decimal CreditTaken { get; set; }

        public decimal TotalTeacherCreditTaken { get; set; }




    }
}