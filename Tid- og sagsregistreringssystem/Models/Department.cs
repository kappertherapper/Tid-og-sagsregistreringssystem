using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tid__og_sagsregistreringssystem.Models
{
    public class Department
    {
        private static int counter = 0; // counter for number
        public string Name { get; set; }
        public int Number { get; set; }
        public Company Company { get; set; }
        private List<TaskManager> Tasks { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public Department(string name, Company company)
        {
            Name = name;
            Number = new Random().Next(1000, 9999);
            Company = company;
            Tasks = new List<TaskManager>();
            Employees = new List<Employee>();
        }

        public List<Employee> GetEmployees => Employees;

        public void AddEmployee(Employee employee)
        {
            if (!Employees.Contains(employee))
            {
                Employees.Add(employee);
                employee.AssignDepartment(this);
            }
        }
    }
}
