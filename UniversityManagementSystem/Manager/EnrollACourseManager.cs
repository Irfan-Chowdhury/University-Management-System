using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class EnrollACourseManager
    {
         private EnrollACourseGateway enrollACourseGateway;
         public EnrollACourseManager()
        {
            enrollACourseGateway = new EnrollACourseGateway();
        }
         public List<Student> GetAllStudentsRegistrationNo()
        {
            return enrollACourseGateway.GetAllStudentsRegistrationNo();
        }

        public List<SaveResultViewModel> GetCourseByStudentId(int studentId)
        {
            return enrollACourseGateway.GetCourseByStudentId(studentId);
        }



        public List<SelectListItem> GetAllStudentsRegistrationNoForDropdown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });

            foreach (Student student in GetAllStudentsRegistrationNo())
            {
                SelectListItem selectList = new SelectListItem();
                selectList.Text = student.RegNo;
                selectList.Value = student.RegNo;
                selectListItems.Add(selectList);
            }
            return selectListItems;
        }

        public List<SaveResultViewModel> GetGrade()
        {
            return enrollACourseGateway.GetGrade();
        }

        public List<SelectListItem> GetGradeForDropdown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });

            foreach (SaveResultViewModel grade in GetGrade())
            {
                SelectListItem selectList = new SelectListItem();
                selectList.Text = grade.Grade;
                selectList.Value =grade.GradeId.ToString();
                selectListItems.Add(selectList);
            }
            return selectListItems;
        }

        public List<SaveResultViewModel> GetStudentByRegNo(string regNo)
        {
            return enrollACourseGateway.GetStudentByRegNo(regNo);
        }


        public string SaveResult(string registrationNo, int courseId, int GradeId)
        {
            int rowAffect = enrollACourseGateway.SaveResult(registrationNo,courseId,GradeId);
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