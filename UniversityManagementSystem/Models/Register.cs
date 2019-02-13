using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Register
    {
        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Please provide Correct Email")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email")]
        public string Email { set; get; }

        [Required(ErrorMessage = "The Field Contact No is Mandatory.")]
        [Phone(ErrorMessage = "Contact No format is Incorrect.")]
        [StringLength(14, MinimumLength = 7, ErrorMessage = "Invalid Phone Number")]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "The Field Date is Mandatory.")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } //Current date will be default date

        [Required]        
        public string Address { get; set; }

        [Required(ErrorMessage = "The Field Department is Mandatory.")]
        [Display(Name = "Department")]
        public int DeptId { get; set; }


        //public virtual Department Department { get; set; }
        [Required]
        //[Display(Name = "Student Reg")]
        public string RegNo { get; set; } // It will be Auto Generated



        public string DepartmentCode { get; set; }




    }
}