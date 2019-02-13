using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Models.ViewModels;

namespace UniversityManagementSystem.Controllers
{
    public class ClassRoomAlocationController : Controller
    {
        private ClassRoomAllocationManager classRoomAllocationManager;

        public ClassRoomAlocationController()
        {
            classRoomAllocationManager = new ClassRoomAllocationManager();
        }
        //
        // GET: /ClassRoomAlocation/
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult ClassroomAllocation()
        {
            ViewBag.Departments = classRoomAllocationManager.GetAllDepartmentByDropdown();
            ViewBag.Courses = classRoomAllocationManager.GetAllCourseByDropdown();

            ViewBag.Rooms = classRoomAllocationManager.GetAllRoomByDropdown();
            ViewBag.Day = classRoomAllocationManager.GetAllDayByDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult ClassroomAllocation(ClassRoomAllocate classRoomAllocate)
        {
            string message = classRoomAllocationManager.Allocate(classRoomAllocate);
            ViewBag.Message = message;
            ViewBag.Departments = classRoomAllocationManager.GetAllDepartmentByDropdown();
            ViewBag.Courses = classRoomAllocationManager.GetAllCourseByDropdown();
            ViewBag.Rooms = classRoomAllocationManager.GetAllRoomByDropdown();
            ViewBag.Day = classRoomAllocationManager.GetAllDayByDropdown();
            return View();
        }
        public JsonResult GetCourseByDepartmentId(int departmentId)
        {
            List<DepartmentViewModel> departmentViewModels = classRoomAllocationManager.GetCourseByDepartmentId(departmentId);
            
            JsonResult jsonResult = Json(departmentViewModels);
            return jsonResult;
        }




        //*************** Unallocate ClassRoom  *****************
        [HttpGet]
        public ActionResult UnallocateClassRooms()
        {

            return View();
        }

        [HttpPost]
        public ActionResult UnallocateClassRooms(string unallocateClassRooms)
        {
            string message = classRoomAllocationManager.UnallocateClassRooms();
            ViewBag.Message = message;
            return View();
        }
    }
}