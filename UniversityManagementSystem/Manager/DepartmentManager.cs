using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class DepartmentManager
    {
        private DepartmentGateway departmentGateway;

        public DepartmentManager()
        {
            departmentGateway=new DepartmentGateway();
        }

        public string Save(Department department)
        {
            if (departmentGateway.IsDepartmentNameExists(department.DepartmentName))
            {
                return "Department Name already Exists";
            }
            else if (departmentGateway.IsDepartmentCodeExists(department.DepartmentCode))
            {
                return "Department Code already Exists";
            }
            else
            {
                int rowAffect = departmentGateway.Save(department);
                if (rowAffect > 0)
                {
                    return "Save Successful";
                }

                else
                {
                    return "Save Failed";
                }
                
            }
            
        }


        public List<Department> GetAllDepartments()
        {
            return departmentGateway.GetAllDepartments();
        }


        //************comment for Testing***********
        //public List<Department> GetAllDepartmentForDropDown()
        //{
        //    List<Department> department = departmentGateway.GetDepartmentList();
        //    List<Department> newDepartment= new List<Department>();
        //    newDepartment.Add(new Department()
        //    {
        //        Id=-1,
        //        DepartmentName= "--Select--"
        //    });

        //    newDepartment.AddRange(department);
        //    return newDepartment;
        //} 




        //***************  My  **********************

        //public List<SelectListItem> GetAllDepartmentForDropDown()
        //{
        //    List<Department> departments = departmentGateway.GetDepartmentList();
        //    List<SelectListItem> selectListItems=new List<SelectListItem>();

        //    foreach (Department department in departments)
        //    {
        //        selectListItems.Add(new SelectListItem()
        //        {
        //            Text = department.DepartmentName,
        //            Value = department.Id.ToString()
        //        });
        //    }
        //    return selectListItems;
        //}




        //*********************By Himel Vai  *******************************

        public List<SelectListItem> GetAllDepartmentForDropDown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });

            foreach (Department departments in GetAllDepartments())
            {
                SelectListItem selectList = new SelectListItem();
                selectList.Text = departments.DepartmentName;
                selectList.Value = departments.Id.ToString();
                selectListItems.Add(selectList);
            }
            return selectListItems;
        }

    }
}