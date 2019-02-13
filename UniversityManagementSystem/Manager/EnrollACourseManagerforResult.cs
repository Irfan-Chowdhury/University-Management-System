using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class EnrollACourseManagerforResult
    {
         private EnrollACourseGatewayforResult enrollACourseGatewayfoResult;
         public EnrollACourseManagerforResult()
        {
            enrollACourseGatewayfoResult = new EnrollACourseGatewayforResult();
        }
         public List<ViewResultModel> GetAllStudentsRegistrationNo()
        {
            return enrollACourseGatewayfoResult.GetAllStudentsRegistrationNo();
        }

        public List<SelectListItem> GetAllStudentsRegistrationNoForDropdown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });

            foreach (ViewResultModel student in GetAllStudentsRegistrationNo())
            {
                SelectListItem selectList = new SelectListItem();
                selectList.Text = student.RegNo;
                selectList.Value = student.RegNo;
                selectListItems.Add(selectList);
            }
            return selectListItems;
        }

        public List<ViewResultModel> GetStudentByRegNo(string regNo)
        {
            return enrollACourseGatewayfoResult.GetStudentByRegNo(regNo);
        }


        
    }
}