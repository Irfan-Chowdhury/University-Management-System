using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class EnrollACourseManagerforEnroll
    {
        private EnrollACourseGatewayforEnroll enrollACourseGatewayforEnroll;
        public EnrollACourseManagerforEnroll()
        {
            enrollACourseGatewayforEnroll = new EnrollACourseGatewayforEnroll();
        }
         public List<EnrollCourse> GetAllStudentsRegistrationNo()
        {
            return enrollACourseGatewayforEnroll.GetAllStudentsRegistrationNo();
        }
         public List<SelectListItem> GetAllStudentsRegistrationNoForDropdown()
         {
             List<SelectListItem> selectListItems = new List<SelectListItem>();
             selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });

             foreach (EnrollCourse student in GetAllStudentsRegistrationNo())
             {
                 SelectListItem selectList = new SelectListItem();
                 selectList.Text = student.RegNo;
                 selectList.Value = student.RegNo;
                 selectListItems.Add(selectList);
             }
             return selectListItems;
         }
         public List<EnrollCourse> GetStudentByRegNo(string regNo)
         {
             return enrollACourseGatewayforEnroll.GetStudentByRegNo(regNo);
         }

         public string SaveEnroll(int studentId, int courseId, string dateValue, int deptId)
        {
             if (enrollACourseGatewayforEnroll.IsEnrollExists(studentId, courseId, deptId))
             {
                 return "This Student already Enrolled in this Course";
             }
             else
             {
                 int rowAffect = enrollACourseGatewayforEnroll.SaveEnroll(studentId, courseId, dateValue, deptId);
                 if (rowAffect > 0)
                 {
                     return "Save Successful";
                 }
                 else
                 {
                     return "Save Failed";
                 }
             }
        }

        


    }
}