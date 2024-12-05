using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class TaskManager
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public int TaskNumber { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public ICollection<TimeStamp> TimeStamps { get; set; }

        public TaskManager()
        {
            
        }

        public TaskManager(string title, int taskNumber, string description)
        {
            Title = title;
            TaskNumber = taskNumber;
            Description = description;
            TimeStamps = new List<TimeStamp>();
        }
    }
}
