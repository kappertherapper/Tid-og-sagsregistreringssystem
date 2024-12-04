using System;

namespace Tid__og_sagsregistreringssystem.Models
{
    public class TimeStamp
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TaskManager Task { get; set; }
        public Employee Employee { get; set; }

        public TimeStamp(DateTime startTime, DateTime endTime, TaskManager task, Employee employee )
        {
            StartTime = startTime;
            EndTime = endTime;
            Task = task;
            Employee = employee;
        }
    }
}
