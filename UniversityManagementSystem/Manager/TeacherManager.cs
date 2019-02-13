using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class TeacherManager
    {
        private TeacherGateway teacherGateway;

        public TeacherManager()
        {
            teacherGateway=new TeacherGateway();
        }

        public string Save(Teacher teacher)
        {
            //if (teacherGateway.IsTeacherNameExists(teacher.TeacherName))
            //{
            //    return "Teacher Name already Exists";
            //}
            if (teacherGateway.IsTeacherEmailExists(teacher.Email))
            {
                return "Teacher Email already Exists";
            }
            else
            {
                int rowAffect = teacherGateway.Save(teacher);
                if (rowAffect > 0)
                {
                    return "Save Succesfull";
                }

                else
                {
                    return "Save Failed";
                }
            }
            
        }


        public List<Teacher> GetAllTeachers()
        {
            return teacherGateway.GetAllTeachers();
        }


        //******************** for Teacher dropdown *******************************

        public List<SelectListItem> GetAllTeacherForDropDown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });

            foreach (Teacher teachers in GetAllTeachers())
            {
                SelectListItem selectList = new SelectListItem();
                selectList.Text = teachers.TeacherName;
                selectList.Value = teachers.Id.ToString();
                selectListItems.Add(selectList);
            }
            return selectListItems;
        }





        //************* for Designation dropdown **************

        public List<SelectListItem> GetAllDesignationForDropDown()
        {
            List<Designation> designations = teacherGateway.GetDesignationList();
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (Designation designation in designations)
            {
                selectListItems.Add(new SelectListItem()
                {
                    Text = designation.DesignationName,
                    Value = designation.Id.ToString()
                });
            }
            return selectListItems;
        }





        //************* For TeacherList By DepartmentId **********************

        public List<Teacher> GetTeachersByDepartmentId(int departmentId)
        {
           return teacherGateway.GetTeachersByDepartmentId(departmentId);

        }



        //************* For Teacher Details by  Teacher.Id **********************

        public Teacher GetTeacherDetailsById(int teacherId)
        {
            return teacherGateway.GetTeacherDetailsById(teacherId);

        }

        ////************************ Total Creit Taken  ***(Transfer in CourseAssign Manager) *********************************************

        //public decimal GetTotalCreditTaken(int teacherId)
        //{
        //    return teacherGateway.GetTotalCreditTaken(teacherId);
        //}


        



        

        //************* For Teacher DropDown **********************

        //public List<Teacher> GetTeachertList()
        //{
        //    return teacherGateway.GetTeacherList();
        //}


        //public List<SelectListItem> GetTeacherByDepartmentId() 
        //{
        //    List<SelectListItem> selectListItems = new List<SelectListItem>();
        //    selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });

        //    foreach (Course courses in GetCourseCodetList())
        //    {
        //        SelectListItem selectList = new SelectListItem();
        //        selectList.Text = courses.CourseCode;
        //        selectList.Value = courses.Id.ToString();
        //        selectListItems.Add(selectList);
        //    }
        //    return selectListItems;
        //}








        //************* Get Teacher By Department dropdown **************

        //public List<Teacher> GetTeachersByDepartmentId(int departmentId)
        //{
        //    return teacherGateway.GetTeachersByDepartmentId(departmentId);
        //} 






        //public List<Designation> GetAllDesignationForDropDown()
        //{
        //    List<Designation> designation = teacherGateway.GetDesignationList();
        //    List<Designation> newdesignation= new List<Designation>();
        //    newdesignation.Add(new Designation()
        //    {
        //        Id = -1,
        //        DesignationName = "--Select--"
        //    });

        //    newdesignation.AddRange(designation);
        //    return newdesignation;
        //} 



    }
}