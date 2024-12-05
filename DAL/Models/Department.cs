using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Department
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Number { get; set; }
            public int CompanyId { get; set; }
            public Company Company { get; set; }
            public ICollection<TaskManager> Tasks { get; set; }
            public ICollection<Employee> Employees { get; set; } = new List<Employee>();

            public Department(string name, Company company, int number)
            {
                Name = name;
                Number = number;   //new Random().Next(1000, 9999);
                Company = company;
                Tasks = new List<TaskManager>();
                Employees = new List<Employee>();
            }

            public ICollection<Employee> GetEmployees => Employees;

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
