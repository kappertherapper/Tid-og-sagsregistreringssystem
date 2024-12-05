using System;

namespace DAL.Models
{
    public class TimeStamp
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TaskId { get; set; }
        public TaskManager Task { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public TimeStamp()
        {
            
        }

        public TimeStamp(DateTime startTime, DateTime endTime, TaskManager task, Employee employee )
        {
            StartTime = startTime;
            EndTime = endTime;
            Task = task;
            Employee = employee;
        }
    }
}
