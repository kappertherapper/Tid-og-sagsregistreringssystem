using System.Collections.Generic;

namespace Registreringssystem.Models
{
    public class Company
    {
        public string Name { get; set; }
        private List<Department> Departments { get; set; }

        public Company(string name) 
        { 
            Name = name;
            Departments = new List<Department>();
        }

        public List<Department> GetDepartments => Departments;
    }
}
