using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tid__og_sagsregistreringssystem.Models
{
    public class Department
    {
        private static int counter = 0; // counter for number
        private string Name { get; set; }
        private int Number { get; set; }
        private Company Company { get; set; }
        private List<TaskManager> Tasks { get; set; }
        private List<Employee> Employees { get; set; }

        public Department()
        {
            
        }

        public Department(string name, Company company)
        {
            Name = name;
            Number = ++counter;
            Company = company;
            Tasks = new List<TaskManager>();
            Employees = new List<Employee>();
        }

        public List<Employee> GetEmployees => Employees;
    }
}
