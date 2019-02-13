using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        //public ActionResult Index()
        //{
        //    return View();
        //}

        private TeacherManager teacherManager;
        private DepartmentManager departmentManager;

        public TeacherController()
        {
            teacherManager=new TeacherManager();
            departmentManager=new DepartmentManager();
        }

        [HttpGet]
        public ActionResult TeacherSave()
        {
            //ViewBag.departmentList = departmentManager.GetAllDepartmentForDropDown();
            //ViewBag.designationList = teacherManager.GetAllDesignationForDropDown();
            ViewBag.departments = departmentManager.GetAllDepartmentForDropDown();
             ViewBag.designations = teacherManager.GetAllDesignationForDropDown();
            return View();
        }

        [HttpPost]
        public ActionResult TeacherSave(Teacher teacher)
        {
            string message = teacherManager.Save(teacher);
            ViewBag.Message = message;
            //ViewBag.departmentList = departmentManager.GetAllDepartmentForDropDown();
            //ViewBag.designationList = teacherManager.GetAllDesignationForDropDown();
            ViewBag.departments = departmentManager.GetAllDepartmentForDropDown();
            ViewBag.designations = teacherManager.GetAllDesignationForDropDown();
            return View();
        }

    }
}