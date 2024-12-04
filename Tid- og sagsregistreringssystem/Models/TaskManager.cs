using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tid__og_sagsregistreringssystem.Models
{
    public class TaskManager
    {
        public string Title { get; set; } 
        public int TaskNumber { get; set; }
        private string Description { get; set; }
        public Department Department { get; set; }
        private Dictionary<TimeStamp, Employee> TimeStamps { get; set; }

        public TaskManager(string title, int taskNumber, string description)
        {
            Title = title;
            TaskNumber = taskNumber;
            Description = description;
            Department = Department;
            TimeStamps = new Dictionary<TimeStamp, Employee>();
        }

        public void AssignDepartment(Department department) // spiller sammen med addTask, og hæver encapsling
        {
            Department = department;
            department.AddTask(this);
        }
    }
}
