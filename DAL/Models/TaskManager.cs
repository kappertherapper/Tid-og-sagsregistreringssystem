using System.Collections.Generic;

namespace DAL.Models
{
    public class TaskManager
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public int TaskNumber { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<TimeStamp> TimeStamps { get; set; }

        public TaskManager(string title, int taskNumber, string description)
        {
            Title = title;
            TaskNumber = taskNumber;
            Description = description;
            TimeStamps = new List<TimeStamp>();
        }

        public void AssignDepartment(Department department) // spiller sammen med addTask, og hæver encapsling
        {
            Department = department;
            Department.Id = department.Id;
            department.AddTask(this);
        }


    }
}
