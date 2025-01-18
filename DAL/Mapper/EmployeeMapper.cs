using DTO.Models;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Mapper
{
    public static class EmployeeMapper
    {
        public static EmployeeDTO Map(Employee employee)
        {
            var DTOemployee = new EmployeeDTO();
            if (employee != null)
            {
                DTOemployee.Id = employee.Id;
                DTOemployee.Name = employee.Name;
                DTOemployee.Cpr = employee.Cpr;
                DTOemployee.Initials = employee.Initials;
                DTOemployee.DepartmentId = employee.DepartmentId ?? 0;

                return DTOemployee;
            }
            else return null;  
        }

        public static Employee Map(EmployeeDTO employee)
        {
            var DALemployee = new Employee();
            if (employee != null)
            {
                DALemployee.Id = employee.Id;
                DALemployee.Name = employee.Name;
                DALemployee.Cpr = employee.Cpr;
                DALemployee.Initials = employee.Initials;
                DALemployee.DepartmentId = employee.DepartmentId;

                return DALemployee;
            }
            else return null;
        }

        public static List<EmployeeDTO> Map(List<Employee> employees)
        {
            return employees.Select(EmployeeMapper.Map).ToList();
        }

        public static List<Employee> Map(List<EmployeeDTO> employeeDTOs)
        {
            return employeeDTOs.Select(EmployeeMapper.Map).ToList();
        }

        internal static void Update(EmployeeDTO employee, Employee dataemp)
        {
            if (employee != null)
            {
                dataemp.Name = employee.Name;
            }
            else
                dataemp = null;
        }
    }
}