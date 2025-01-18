using DAL.Repository;
using DTO.Models;
using System;
using System.Collections.Generic;

namespace BLL.BLL
{
    public class EmployeeBLL
    {
        public EmployeeBLL() { }
        public EmployeeDTO GetEmployee(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return EmployeeRepository.GetEmployee(id);
        }

        public static List<EmployeeDTO> GetAllEmployees()
        {
            return EmployeeRepository.GetAllEmployees();
        }

        public static List<EmployeeDTO> GetAllEmployeesByDepartment(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Department ID must be a positive integer.", nameof(id));
            }
            return EmployeeRepository.GetAllEmployeesByDepartment(id);
        }
        public static void AddEmployee(EmployeeDTO employee)
        {
            if (employee == null) throw new ArgumentNullException();
            EmployeeRepository.AddEmployee(employee);
        }
        public static void EditEmployee(EmployeeDTO employee)
        {
            if (employee == null) throw new ArgumentNullException();
            EmployeeRepository.EditEmployee(employee);
        }
    }
}
