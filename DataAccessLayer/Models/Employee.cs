using System;

namespace DataAccessLayer.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public string Initials { get; set; }
        public string Cpr { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public Employee()
        {
            
        }

        public Employee(string name, string cpr)
        {
            Name = name;
            Initials = string.IsNullOrEmpty(Name) ? "" : Name.Substring(0, Math.Min(2, Name.Length));
            Cpr = cpr;
        }

        public void AssignDepartment(Department department) // spiller sammen med addEmployee, og hæver encapsling
        {
            this.Department = department;
            Department.Id = department.Id;
            department.AddEmployee(this);
        }

        public string GetName() => Name;
        public string GetInitials() => Initials;
        public string GetCpr() => Cpr;

        public void SetName(string name) => Name = name;
        public void SetInitials(string initials) => Initials = initials;
        public void SetCpr(string cpr) => Cpr = cpr;
    }
}
