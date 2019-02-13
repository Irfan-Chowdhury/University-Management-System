using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class CourseManager
    {
        private CourseGateway courseGateway;

        public CourseManager()
        {
            courseGateway=new CourseGateway();
        }

        public string Save(Course course)
        {
            if (courseGateway.IsCourseNameExists(course.CourseName))
            {
                return "Course Name already Exists";
            }
            else if (courseGateway.IsCourseCodeExists(course.CourseCode))
            {
                return "Course Code already Exists";
            }
            else
            {
                int rowAffect = courseGateway.Save(course);
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


        //******************** for Get All Course *******************************

        public List<Course> GetAllCourses()
        {
            return courseGateway.GetAllCourses();
        }

        //******************** for Course dropdown *******************************

        public List<SelectListItem> GetAllCourseForDropDown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });

            foreach (Course courses in GetAllCourses())
            {
                SelectListItem selectList = new SelectListItem();
                selectList.Text = courses.CourseName;
                selectList.Value = courses.Id.ToString();
                selectListItems.Add(selectList);
            }
            return selectListItems;
        }



        //*********************Get Course By Department ID *******************************

        public List<Course> GetCoursesByDepartmentId(int departmentId)
        {
           return courseGateway.GetCoursesByDepartmentId(departmentId);
        }



        //************* For Teacher Details by  Teacher.Id **********************

        public Course GetCourseDetailsById(int courseId)
        {
            return courseGateway.GetCourseDetailsById(courseId);

        }

        


        //*********************Semester Dropdwon Dropdown *******************************

        public List<SelectListItem> GetAllSemesterForDropDown()
        {
            List<Semester> semesters = courseGateway.GetSemesterList();
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (Semester semester in semesters)
            {
                selectListItems.Add(new SelectListItem()
                {
                    Text = semester.SemesterName,
                    Value = semester.Id.ToString()
                });
            }
            return selectListItems;
        }



        //*********************By Himel Vai Course Dropdown *******************************
        //public List<Course> GetCourseCodetList()
        //{
        //    return courseGateway.GetCourseCodetList();
        //}


        //public List<SelectListItem> GetAllCourseCodetForDropDown()
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






        //**********************Old Method ***********************
        //public List<Semester> GetAllSemesterForDropDown()
        //{
        //    List<Semester> semester = courseGateway.GetSemesterList();
        //    List<Semester> newsemester = new List<Semester>();
        //    newsemester.Add(new Semester()
        //    {
        //        Id = -1,
        //        SemesterName = "--Select--"
        //    });

        //    newsemester.AddRange(semester);
        //    return newsemester;
        //} 


        
    }
}