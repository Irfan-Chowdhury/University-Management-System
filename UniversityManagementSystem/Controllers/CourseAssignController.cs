using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class CourseAssignController : Controller
    {
        // GET: CourseAssignTeacher
        //public ActionResult Index()
        //{
        //    return View();
        //}

        private DepartmentManager departmentManager;
        private TeacherManager teacherManager;
        private CourseAssignManager courseAssignManager;
        private CourseManager courseManager;

        public CourseAssignController()
        {
            departmentManager=new DepartmentManager();
            teacherManager=new TeacherManager();
            courseAssignManager =new CourseAssignManager();
            courseManager=new CourseManager();
        }

        [HttpGet]
        public ActionResult CourseAssign( )
        {
            
            ViewBag.departments = departmentManager.GetAllDepartmentForDropDown();
            ViewBag.courses = courseManager.GetAllCourseForDropDown();
            return View();
        }

        [HttpPost]
        public ActionResult CourseAssign(CourseAssignTeacher courseAssignTeacher)
        {
            string message = courseAssignManager.AssignCourse(courseAssignTeacher);
            ViewBag.Message = message;
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropDown();
            ViewBag.Courses = courseManager.GetAllCourseForDropDown();
            return View();
        }




        public JsonResult GetTeachersByDepartmentId(int departmentId)
        {
            List<Teacher> teacherList = teacherManager.GetTeachersByDepartmentId(departmentId);
                
            return Json(teacherList);
        }


        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            List<Course> coursesList = courseManager.GetCoursesByDepartmentId(departmentId);

            return Json(coursesList);
        }




        public JsonResult GetTeacherDetailsById(int teacherId)
        {
            Teacher teacher = teacherManager.GetTeacherDetailsById(teacherId);
            teacher.TotalTeacherCreditTaken = courseAssignManager.GetTotalCreditTaken(teacherId);

           
            return Json(teacher);
        }



        public JsonResult GetCourseDetailsById(int courseId)
        {
            Course course = courseManager.GetCourseDetailsById(courseId);

            return Json(course);
        }




        //******************** For UnAssign 13 Story*********************


        [HttpGet]
        public ActionResult UnAssignCourse()
        {

            return View();
        }

        [HttpPost]
        public ActionResult UnAssignCourse(string unAssignCourse)
        {
            string message = courseAssignManager.UnAssignCourse();
            ViewBag.Message = message;            
            return View();
        }
















        //************* For View *************

        //[HttpGet]
        //public ActionResult ViewCourseStatics()
        //{
        //    ViewBag.departments = departmentManager.GetAllDepartmentForDropDown();
        //    return View();
        //}


        //public JsonResult GetCourseInfoByDepartmentId(int departmentId)
        //{
        //    List<CourseStaticsViewModel> courseStaticsViewModelList = courseAssignManager.GetCourseInfoByDepartmentId(departmentId);

        //    JsonResult jsonResult = Json(courseStaticsViewModelList);

        //    return jsonResult;
        //    //return Json(courseStaticsViewModelList);
        //}



    }
}