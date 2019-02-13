using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class CourseAssignManager
    {
        private CourseAssignGateway courseAssignGateway;

        public CourseAssignManager()
        {
            courseAssignGateway = new CourseAssignGateway();
        }


        //************************* For Assign *******************
        public string AssignCourse(CourseAssignTeacher courseAssignTeacher)
        {
            if (courseAssignGateway.IsCourseExists(courseAssignTeacher.CourseId))
            {
                return "This Course already has been taken";
            }
            else
            {
                int rowAffect = courseAssignGateway.AssignCourse(courseAssignTeacher);
                if (rowAffect > 0)
                {
                    return "Assign Successful";
                }

                else
                {
                    return "Assign Failed";
                }
            }
            
        }



        //************************ Total Creit Taken *********************************************

        public decimal GetTotalCreditTaken(int teacherId)
        {
            return courseAssignGateway.GetTotalCreditTaken(teacherId);
        }



        //************************* For UnAssign *******************

        public string UnAssignCourse()
        {            
            int rowAffect = courseAssignGateway.UnAssignCourse();
            if (rowAffect > 0)
            {
                return "UnAssign Successful";
            }
            else
            {
                return "UnAssign Failed";
            }            
        }








        //************************************** For 6th Story  By Warid *********************************


        public List<CourseStaticsViewModel> GetCourseStatitics(string deptName)
        {
            return courseAssignGateway.GetCourseStatitics(deptName);
        }

        public List<CourseStaticsViewModel> GetAllSDepartments()
        {
            return courseAssignGateway.GetAllSDepartments();

        }
                                                               //------------->> create problem that's why i comment this drop down

        public List<SelectListItem> GetAllSDepartmentsForDropdown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });

            foreach (CourseStaticsViewModel department in GetAllSDepartments())
            {
                SelectListItem selectList = new SelectListItem();
                selectList.Text = department.DepartmentName;
                selectList.Value = department.DepartmentName;
                selectListItems.Add(selectList);
            }
            return selectListItems;
        }



        //******************************************* End 6th Story *****************************








        //public List<CourseStaticsViewModel> GetCourseInfoByDepartmentId(int departmentId)
        //{
        //    return courseAssignGateway.GetCourseInfoByDepartmentId(departmentId);
        //}


    }
}