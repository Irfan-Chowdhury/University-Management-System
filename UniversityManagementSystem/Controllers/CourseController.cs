using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        //public ActionResult Index()
        //{
        //    return View();
        //}

        private CourseManager courseManager;
        private DepartmentManager departmentManager;
        private CourseAssignManager courseAssignManager; //---this line ---------for warid

        public CourseController()
        {
            courseManager=new CourseManager();
            departmentManager=new DepartmentManager();
            courseAssignManager = new CourseAssignManager();   //----this line--------for warid
        }

        [HttpGet]
        public ActionResult CourseSave()
        {
            //ViewBag.departmentList = departmentManager.GetAllDepartmentForDropDown();
            //ViewBag.semesterList = courseManager.GetAllSemesterForDropDown();
            ViewBag.departments = departmentManager.GetAllDepartmentForDropDown();
            ViewBag.semesters = courseManager.GetAllSemesterForDropDown();
            
            return View();
        }

        [HttpPost]
        public ActionResult CourseSave(Course course)
        {
            string message = courseManager.Save(course);
            ViewBag.Message = message;
            ViewBag.departments = departmentManager.GetAllDepartmentForDropDown();
            ViewBag.semesters = courseManager.GetAllSemesterForDropDown();
            //ViewBag.departmentList = departmentManager.GetAllDepartmentForDropDown();
            //ViewBag.semesterList = courseManager.GetAllSemesterForDropDown();
            
            return View();
        }






//*********************************** for 6th Story By Warid *************************************************** 

        public JsonResult GetCourseStatitics(string deptName)
        {
            //List<StudentViewModel> studentViewModels = studentManager.GetStudentsByDepartmentId(deptId);
            List<CourseStaticsViewModel> courseStatics = courseAssignManager.GetCourseStatitics(deptName);

            JsonResult jsonResult = Json(courseStatics);
            return jsonResult;
        }

        public ActionResult GetAllDepartments()
        {
            ViewBag.Departmentss = courseAssignManager.GetAllSDepartmentsForDropdown();  //this is warid's drop down

            ViewBag.Departments = departmentManager.GetAllDepartmentForDropDown();   //this is irfan's drop down

            return View();
        }
    }
}