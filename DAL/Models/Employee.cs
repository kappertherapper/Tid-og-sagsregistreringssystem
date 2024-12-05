using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public string Initials { get; set; }
        public string Cpr { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public Employee()
        {
            
        }

        public Employee(string name, string cpr)
        {
            Name = name;
            Initials = string.IsNullOrEmpty(Name) ? "" : Name.Substring(0, Math.Min(2, Name.Length));
            Cpr = cpr;
        }

      

        public string GetName() => Name;
        public string GetInitials() => Initials;
        public string GetCpr() => Cpr;

        public void SetName(string name) => Name = name;
        public void SetInitials(string initials) => Initials = initials;
        public void SetCpr(string cpr) => Cpr = cpr;
    }
}
