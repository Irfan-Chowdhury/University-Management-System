using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ViewResultController : Controller
    {
        //
        // GET: /ViewResult/
        private EnrollACourseManagerforResult enrollACourseManagerforResult;


        public ViewResultController()
        {
            enrollACourseManagerforResult = new EnrollACourseManagerforResult();
           
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewStudentResult()
        {
            ViewBag.RegistrationNo = enrollACourseManagerforResult.GetAllStudentsRegistrationNoForDropdown();
            //ViewBag.Grade = enrollACourseManager.GetGradeForDropdown();
            return View();
        }


        public JsonResult GetStudent(string regNo)
        {
            //List<StudentViewModel> studentViewModels = studentManager.GetStudentsByDepartmentId(deptId);
            List<ViewResultModel> students = enrollACourseManagerforResult.GetStudentByRegNo(regNo);

            JsonResult jsonResult = Json(students);
            return jsonResult;
        }
        
	}
}