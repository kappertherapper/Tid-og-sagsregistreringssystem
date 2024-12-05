using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        public DepartmentDTO()
        {
            
        }

        public DepartmentDTO(string name, int number)
        {
            Name = name;
            Number = number;
        }

    }
}
