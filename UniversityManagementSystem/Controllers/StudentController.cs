using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
        private EnrollACourseManager enrollACourseManager;
       

        public StudentController()
        {
            enrollACourseManager = new EnrollACourseManager();
           
        }
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult SaveStudentResult()
        {
            ViewBag.RegistrationNo = enrollACourseManager.GetAllStudentsRegistrationNoForDropdown();
            ViewBag.Grade = enrollACourseManager.GetGradeForDropdown();
            return View();
        }
        public JsonResult GetStudentByRegNo(string regNo)
        {
            //List<StudentViewModel> studentViewModels = studentManager.GetStudentsByDepartmentId(deptId);
            List<SaveResultViewModel> students = enrollACourseManager.GetStudentByRegNo(regNo);

            JsonResult jsonResult = Json(students);
            return jsonResult;
        }

        public JsonResult GetCourseByStudentId(int studentId)
        {
            //List<StudentViewModel> studentViewModels = studentManager.GetStudentsByDepartmentId(deptId);
           // List<SaveResultViewModel> students = enrollACourseManager.GetStudentByRegNo(regNo);
            List<SaveResultViewModel> courses = enrollACourseManager.GetCourseByStudentId(studentId);

            JsonResult jsonResult = Json(courses);
            return jsonResult;
        }

        public JsonResult GetInfo(string registrationNo, int courseId, int GradeId)
        {
            var message1 = enrollACourseManager.SaveResult(registrationNo, courseId, GradeId);

            JsonResult jsonResult = Json(message1, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }



	}
}