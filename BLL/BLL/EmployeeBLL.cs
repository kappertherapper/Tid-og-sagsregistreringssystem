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

        public List<EmployeeDTO> GetAllEmployees()
        {
            return EmployeeRepository.GetAllEmployees();
        }
        public int AddEmployee(EmployeeDTO employee)
        {
            if (employee == null) throw new ArgumentNullException();
            return EmployeeRepository.AddEmployee(employee);
        }
        public void EditEmployee(EmployeeDTO employee)
        {
            if (employee == null) throw new ArgumentNullException();
            EmployeeRepository.EditEmployee(employee);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var BLL = new EmployeeBLL();
            var employees = BLL.GetAllEmployees();

            Console.WriteLine("Jobs retrieved:");
            foreach (var e in employees)
            {
                Console.WriteLine(e.Name);
            }
        }
    }
}
