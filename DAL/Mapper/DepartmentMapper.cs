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
            DepartmentDTO DTOdepartment = new DepartmentDTO();
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
            Department DALdepartment = new Department();
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
            List<DepartmentDTO> retur = new List<DepartmentDTO>();
            foreach (var department in departments)
            {
                retur.Add(DepartmentMapper.Map(department));
            }
            return retur;
        }

        public static List<Department> Map(List<DepartmentDTO> departmentDTOs)
        {
            List<Department> retur = new List<Department>();
            foreach (var departmentDTO in departmentDTOs)
            {
                retur.Add(DepartmentMapper.Map(departmentDTO));
            }
            return retur;
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
