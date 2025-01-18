using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using DTO.Models;

namespace BLL.BLL
{
    public class DepartmentBLL
    {
        public DepartmentBLL()
        {
            
        }
        public DepartmentDTO GetDepartment(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return DepartmentRepository.GetDepartment(id);
        }

        public static List<DepartmentDTO> GetAllDepartments()
        {
            return DepartmentRepository.GetAllDepartments();
        }

        public int AddDepartment(DepartmentDTO department)
        {
            if (department == null) throw new ArgumentNullException();
            return DepartmentRepository.AddDepartment(department);
        }

        public void EditDepartment(DepartmentDTO department)
        {
            if (department == null) throw new ArgumentNullException();
            DepartmentRepository.EditDepartment(department);
        }

    }
}
