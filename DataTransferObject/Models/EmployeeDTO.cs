using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.Models
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }

        public EmployeeDTO()
        {
            
        }

        public EmployeeDTO(string name)
        {
            Name = name;
            Initials = string.IsNullOrEmpty(Name) ? "" : Name.Substring(0, Math.Min(2, Name.Length));
        }
    }

}
