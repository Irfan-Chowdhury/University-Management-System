using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models.ViewModels;


namespace UniversityManagementSystem.Controllers
{
    public class ClassScheduleAndRoomAllocationInformationController : Controller
    {
        private ClassAndRoomInfoManager classAndRoomInfoManager;
        private ClassRoomAllocationManager classRoomAllocationManager;

        public ClassScheduleAndRoomAllocationInformationController()
        {
            classAndRoomInfoManager = new ClassAndRoomInfoManager();
            classRoomAllocationManager = new ClassRoomAllocationManager();
        }
        //
        // GET: /ClassScheduleAndRoomAllocationInformation/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewClassAndRoomByDeptId()
        {
            ViewBag.Departments = classRoomAllocationManager.GetAllDepartmentByDropdown();

            return View();
        }

        public JsonResult GetClassAndRoomByDeptId(int deptId)
        {
            List<ClassAndRoomViewModel> classAndRoomView = classAndRoomInfoManager.GetClassAndRoomByDeptId(deptId);
            JsonResult jsonResult = Json(classAndRoomView);
            return jsonResult;
        }
    }
}