using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Designation
    {
        public int Id { get; set; }


        [Display(Name = "Designation")]
        [Required]
        public string DesignationName { get; set; } 
    }
}