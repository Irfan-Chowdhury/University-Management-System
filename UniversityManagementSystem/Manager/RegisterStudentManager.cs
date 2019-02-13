using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class RegisterStudentManager
    {
        private RegisterStudentGateway registerStudentGateway;

        public RegisterStudentManager()
        {
            registerStudentGateway = new RegisterStudentGateway();

        }


        public string Save(Register register)
        {
            if (registerStudentGateway.IsEmailExists(register.Email))
            {
                return "Email Already Exist";
            }
            else
            {
                int rowAffect = registerStudentGateway.Save(register);
                if (rowAffect > 0)
                {
                    return register.RegNo;
                   

                }
                else
                {
                    return "Student not Saved";
                }
                

            }

        }

        public int GetStudentSerial(Register register)
        {
            return registerStudentGateway.GetStudentSerial(register);
        }







        public List<Department> GetDepartmentList()
        {
            return registerStudentGateway.GetDepartmentList();
        }


                //***for deptcode***********************


        public string GetDepartmentCodeById(int departmentId)
        {
            string departmentCode = registerStudentGateway.GetDepartmentCodeById(departmentId);
            return departmentCode;
        }

        public int GetStudentId(Register register)
        {
            return registerStudentGateway.GetStudentId(register);
        }

        public string finalRegNo(Register register)
        {
            int rowAffect = registerStudentGateway.finalRegNo(register);
            if (rowAffect > 0)
            {

                return "Registration Successful with   Student Name: " + register.Name + ";  Address: " + register.Address +
                    ";  Contact No: " + register.ContactNo + ";  Email: " + register.Email + ";  Department: " + register.DepartmentCode + ";  Registration No: " + register.RegNo; 

            }
            else
            {
                return "Student not Saved";
            }
        }







        //***************collect From departmentGateway *******************************

        public List<Department> GetAllDepartments()
        {
            return registerStudentGateway.GetAllDepartments();
        }



        public List<SelectListItem> GetAllDepartmentForDropdown()
        {
            List<Department> departments = registerStudentGateway.GetAllDepartments();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (Department department in departments)
            {
                selectListItems.Add(new SelectListItem()
                {
                    Text = department.DepartmentName,
                    Value = department.Id.ToString()
                });
            }
            return selectListItems;

        } 



    }
}