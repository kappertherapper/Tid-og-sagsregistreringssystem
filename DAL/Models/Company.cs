using System.Collections.Generic;

namespace DAL.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Department> Departments { get; set; }

        public Company(string name) 
        { 
            Name = name;
            Departments = new List<Department>();
        }

        public ICollection<Department> GetDepartments => Departments;
    }
}
