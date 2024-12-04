using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class TaskManager
    {
        public string Title { get; set; } 
        public int TaskNumber { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public Dictionary<TimeStamp, Employee> TimeStamps { get; set; }

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
            Department.Id = department.Id;
            department.AddTask(this);
        }
    }
}
