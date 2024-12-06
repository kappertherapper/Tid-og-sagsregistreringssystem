using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class TaskManagerDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TaskNumber { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }

        public TaskManagerDTO()
        {
            
        }
        public TaskManagerDTO(string title, int taskNumber, string description, int departmentId)
        {
            Title = title;
            TaskNumber = taskNumber;
            Description = description;
            DepartmentId = departmentId;
        }
    }
}
