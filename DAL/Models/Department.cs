using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Department
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Number { get; set; }

        public Department()
        {
            
        }

        public Department(string name, int number)
            {
                Name = name;
                Number = number;
            }
        }
    }
