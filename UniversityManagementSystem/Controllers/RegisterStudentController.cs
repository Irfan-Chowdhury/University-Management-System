using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
     
    public class RegisterStudentController : Controller
    {
        private RegisterStudentManager registerStudentManager;
        private DepartmentManager departmentManager;
     

        public RegisterStudentController()
        {
                 registerStudentManager = new RegisterStudentManager();
                 departmentManager = new DepartmentManager();
        }

       

       [HttpGet]
        public ActionResult Save()
       {
           //ViewBag.departments = departmentManager.GetAllDepartments();               //------------> change*********
           ViewBag.departments = registerStudentManager.GetAllDepartments();

            return View();
        }


        [HttpPost]
       public ActionResult Save(Register register)
       {
           string departmentCode = registerStudentManager.GetDepartmentCodeById(register.DeptId);

           register.DepartmentCode = departmentCode;


           string regno = departmentCode + "-";
           regno += register.Date.Year.ToString();
           regno += "-";
           register.RegNo = regno;

           string message = registerStudentManager.Save(register);
           int serialNo = registerStudentManager.GetStudentSerial(register);
           int studentId = registerStudentManager.GetStudentId(register);
            register.StudentId = studentId;



            if (serialNo == 0)
            {
                regno += "00" + serialNo;
            }
            else
            {
                if (serialNo >= 1 && serialNo <= 9)
                {
                    int temp = serialNo;
                    regno += "00" + temp;
                }
                else if (serialNo >= 10 && serialNo <= 99)
                {
                    int temp = serialNo;
                    regno += "0" + temp;

                }
                else
                {
                    regno += "" + serialNo;

                }


            }
            register.RegNo = regno;

            string messageFinal = registerStudentManager.finalRegNo(register);


            ViewBag.Message = messageFinal;
            //ViewBag.departments = departmentManager.GetAllDepartments();           //------------> change**********************
            ViewBag.departments = registerStudentManager.GetAllDepartments();



           // int serialNo = registerStudentManager.GetStudentSerial(register);
            //****For RegNo Showing****************************

            //string departmentCode = registerStudentManager.GetDepartmentCodeById(register.DeptId);

            //register.DepartmentCode = departmentCode;
           

            //string regno = departmentCode + "-";
            //regno += register.Date.Year.ToString();
            //regno += "-";


            
           
            //register.RegNo = regno;


            //string registerStudent = registerStudentManager.Save(register);
            //ViewBag.message = registerStudent;

           

           return View();
       }
	}
}