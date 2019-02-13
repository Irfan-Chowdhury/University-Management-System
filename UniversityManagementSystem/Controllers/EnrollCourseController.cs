using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class EnrollCourseController : Controller
    {
        //
        // GET: /EnrollCourse/

        private EnrollACourseManagerforEnroll enrollACourseManagerforEnroll;


        public EnrollCourseController()
        {
            enrollACourseManagerforEnroll = new EnrollACourseManagerforEnroll();
           
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EnrollCourse()
        {
            ViewBag.RegistrationNo = enrollACourseManagerforEnroll.GetAllStudentsRegistrationNoForDropdown();

            return View();
        }
        public JsonResult GetStudent(string regNo)
        {
            List<EnrollCourse> students = enrollACourseManagerforEnroll.GetStudentByRegNo(regNo);

            JsonResult jsonResult = Json(students);
            return jsonResult;
        }

        public JsonResult GetInfo(int studentId, int courseId, string dateValue, int deptId)
        {
            var message1 = enrollACourseManagerforEnroll.SaveEnroll(studentId, courseId, dateValue,deptId);

            JsonResult jsonResult = Json(message1, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

	}
}