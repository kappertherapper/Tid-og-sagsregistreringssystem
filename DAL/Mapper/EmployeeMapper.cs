using DTO.Models;
using DAL.Models;
using System.Collections.Generic;

namespace DAL.Mapper
{
    public static class EmployeeMapper
    {
        public static EmployeeDTO Map(Employee employee)
        {
            EmployeeDTO DTOemployee = new EmployeeDTO();
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
            Employee DALemployee = new Employee();
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
            List<EmployeeDTO> retur = new List<EmployeeDTO>();
            foreach (var employee in employees)
            {
                retur.Add(EmployeeMapper.Map(employee));
            }
            return retur;
        }

        public static List<Employee> Map(List<EmployeeDTO> employeeDTOs)
        {
            List<Employee> retur = new List<Employee>();
            foreach (var employeeDTO in employeeDTOs)
            {
                retur.Add(EmployeeMapper.Map(employeeDTO));
            }
            return retur;
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