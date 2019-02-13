using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Models.ViewModels;

namespace UniversityManagementSystem.Manager
{
    public class ClassRoomAllocationManager
    {
        private ClassRoomAllocationGateway classRoomAllocationGateway;

        public ClassRoomAllocationManager()
        {
            classRoomAllocationGateway = new ClassRoomAllocationGateway();
        }

        //*************************************Allocate Classroom *****************************
        public string Allocate(ClassRoomAllocate classRoomAllocate)
        {
            if (classRoomAllocationGateway.IsSheduleTimeExists(classRoomAllocate))
            {
                return "Shedule Already Exist";
            }
            else
            {
                int rowEffect = classRoomAllocationGateway.Allocate(classRoomAllocate);
                if (rowEffect > 0)
                {
                    return "Save Successfull";
                }
                else
                {
                    return "Save Failed";
                }
            }
           
        }

        //***********************DEPARTMENT DROPDOWN*********************************

        public List<Department> GetAllDepartments()
        {
            return classRoomAllocationGateway.GetAllDepartments();
        }

        public List<SelectListItem> GetAllDepartmentByDropdown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem(){Text = "--Select--" , Value = ""});

            foreach (Department department in GetAllDepartments())
            {
                SelectListItem selectListItem =new SelectListItem();
                selectListItem.Text = department.DepartmentName;
                selectListItem.Value = department.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

        //public List<DepartmentViewModel> GetDepartmentByDepartmentId(int departmentId)
        //{
        //    return classRoomAllocationGateway.GetDepartmentByDepartmentId(departmentId);
        //}

        //***********************COURSE DROPDOWN*********************************

        public List<Course> GetAllCourses()
        {
            return classRoomAllocationGateway.GetAllCourses();
        }

        public List<SelectListItem> GetAllCourseByDropdown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });

            foreach (Course course in GetAllCourses())
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = course.CourseName;
                selectListItem.Value = course.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

        public List<DepartmentViewModel> GetCourseByDepartmentId(int departmentId)
        {
            return classRoomAllocationGateway.GetCourseByDepartmentId(departmentId);
        }

        //***********************Room DROPDOWN*********************************
        public List<Room> GetAllRooms()
        {
            return classRoomAllocationGateway.GetAllRooms();
        }

        public List<SelectListItem> GetAllRoomByDropdown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });

            foreach (Room room in GetAllRooms())
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = room.RoomNo;
                selectListItem.Value = room.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }
        //***********************DAY DROPDOWN*********************************

        public List<Day> GetAllDay()
        {
            return classRoomAllocationGateway.GetAllDay();
        }

        public List<SelectListItem> GetAllDayByDropdown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });

            foreach (Day day in GetAllDay())
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = day.DayName;
                selectListItem.Value = day.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

       


        //**********************  Unallocated All ClassRoom **********************

        public string UnallocateClassRooms()
        {
            int rowAffect = classRoomAllocationGateway.UnallocateClassRooms();
            if (rowAffect > 0)
            {
                return "Unallocate Classrooms Successful";
            }
            else
            {
                return "Unallocate Classrooms Failed";
            }   
        } 
    }
}