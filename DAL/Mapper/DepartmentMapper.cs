using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DTO.Models;

namespace DAL.Mapper
{
    public class DepartmentMapper
    {
        public static DepartmentDTO Map(Department department)
        {
            var DTOdepartment = new DepartmentDTO();
            if (department != null)
            {
                DTOdepartment.Id = department.Id;
                DTOdepartment.Name = department.Name;
                return DTOdepartment;
            }
            else return null;
        }

        public static Department Map(DepartmentDTO departmentDTO)
        {
            var DALdepartment = new Department();
            if (departmentDTO != null)
            {
                DALdepartment.Id = departmentDTO.Id;
                DALdepartment.Name = departmentDTO.Name;
                DALdepartment.Number = departmentDTO.Number;

                return DALdepartment;
            }
            else return null;
        }

        public static List<DepartmentDTO> Map(List<Department> departments)
        {
            return departments.Select(DepartmentMapper.Map).ToList();
        }

        public static List<Department> Map(List<DepartmentDTO> departmentDTOs)
        {
            return departmentDTOs.Select(DepartmentMapper.Map).ToList();
        }

        internal static void Update(DepartmentDTO department, Department data)
        {
            if (department != null)
            {
                data.Name = department.Name;
                data.Number = department.Number;
            }
            else
                data = null;
        }
    }
}
