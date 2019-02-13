using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystem.Models
{
    public class Department
    {
        
        public int Id { get; set; }


        [Required(ErrorMessage = "Please provide Department Code")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Department Code must be 2 to 7 character long")]
        
        public string DepartmentCode { get; set; }


        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please provide Department Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Department Name must be 2 to 50 character long")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string DepartmentName { get; set; }
    }
}