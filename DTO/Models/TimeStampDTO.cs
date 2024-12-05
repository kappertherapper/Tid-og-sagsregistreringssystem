using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class TimeStampDTO
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }

        public TimeStampDTO()
        {
            
        }

        public TimeStampDTO(DateTime startTime, DateTime endTime, int taskId, int employeeId)
        {
            StartTime = startTime;
            EndTime = endTime;
            TaskId = taskId;
            EmployeeId = employeeId;
        }
    }
}
