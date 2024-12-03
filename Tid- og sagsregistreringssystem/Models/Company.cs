using System.Collections.Generic;

namespace Tid__og_sagsregistreringssystem.Models
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
