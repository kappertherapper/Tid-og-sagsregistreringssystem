using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; }

        public Company(string name) 
        { 
            Name = name;
            Departments = new List<Department>();
        }

        public List<Department> GetDepartments => Departments;
    }
}
