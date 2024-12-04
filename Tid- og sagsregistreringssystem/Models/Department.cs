using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tid__og_sagsregistreringssystem.Models
{
    public class Department
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public Company Company { get; set; }
        private List<TaskManager> Tasks { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public Department(string name, Company company, int number)
        {
            Name = name;
            Number = number;   //new Random().Next(1000, 9999);
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

        public void AddTask(TaskManager task)
        {
            if (!Tasks.Contains(task))
            {
                Tasks.Add(task);
                task.AssignDepartment(this);
            }
        }
    }
}
