using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        //public ActionResult Index()
        //{
        //    return View();
        //}

        private DepartmentManager departmentManager;

        public DepartmentController()
        {
            departmentManager=new DepartmentManager();
        }

        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Department department)
        {
            string message= departmentManager.Save(department);
            ViewBag.Message = message;
            return View();
        }



        public ActionResult GetAllDepartments()
        {
            List<Department> departmentList = departmentManager.GetAllDepartments();
            return View(departmentList);
        }












        //public string FindById(int id)
        //{
        //    Department department = departmentManager.FindById(id);
        //    return department.DepartmentCode + " " + department.DepartmentName;
        //}


        //public string Index()
        //{
        //    return "Hello from Department/index";
        //}
    }
}