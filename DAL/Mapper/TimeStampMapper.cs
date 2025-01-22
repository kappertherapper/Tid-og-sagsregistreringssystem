using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using DAL.Models;

namespace DAL.Mapper
{
    public static class TimeStampMapper 
    {
        public static TimeStampDTO Map(TimeStamp timeStamp)
        {
            var DTOtimeStamp = new TimeStampDTO();
            
            if (timeStamp == null) return null;
            DTOtimeStamp.StartTime = timeStamp.StartTime;
            DTOtimeStamp.EndTime = timeStamp.EndTime;
            DTOtimeStamp.TaskId = timeStamp.TaskId;
            DTOtimeStamp.EmployeeId = timeStamp.EmployeeId;
                

            return DTOtimeStamp;

        }

        public static TimeStamp Map(TimeStampDTO DTOtimeStamp)
        {
            var timeStamp = new TimeStamp();
            
            if (DTOtimeStamp == null) return null;
            timeStamp.StartTime = DTOtimeStamp.StartTime;
            timeStamp.EndTime = DTOtimeStamp.EndTime;
            timeStamp.TaskId = DTOtimeStamp.TaskId;
            timeStamp.EmployeeId = DTOtimeStamp.EmployeeId;
                

            return timeStamp;

        }

        public static List<TimeStampDTO> Map(List<TimeStamp> timeStamps)
        {
            return timeStamps.Select(Map).ToList();
        }

        public static List<TimeStamp> Map(List<TimeStampDTO> timeStampDTOs)
        {
            return timeStampDTOs.Select(Map).ToList();
        }
    }
}
