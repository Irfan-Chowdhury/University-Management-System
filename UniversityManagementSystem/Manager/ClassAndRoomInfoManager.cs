using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models.ViewModels;

namespace UniversityManagementSystem.Manager
{
    public class ClassAndRoomInfoManager
    {
        private ClassAndRoomInfoGateway classAndRoomInfoGateway;

        public ClassAndRoomInfoManager()
        {
            classAndRoomInfoGateway = new ClassAndRoomInfoGateway();
        }

        public List<ClassAndRoomViewModel> GetClassAndRoomByDeptId(int departmentId)
        {
            return classAndRoomInfoGateway.GetClassAndRoomByDeptId(departmentId);
        }

    }
}