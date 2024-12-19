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
            TimeStampDTO DTOtimeStamp = new TimeStampDTO();
            if (timeStamp != null)
            {
                DTOtimeStamp.StartTime = timeStamp.StartTime;
                DTOtimeStamp.EndTime = timeStamp.EndTime;
                DTOtimeStamp.TaskId = timeStamp.TaskId;
                DTOtimeStamp.EmployeeId = timeStamp.EmployeeId;
                

                return DTOtimeStamp;
            }
            else return null;
        }

        public static TimeStamp Map(TimeStampDTO DTOtimeStamp)
        {
            TimeStamp timeStamp = new TimeStamp();
            if (DTOtimeStamp != null)
            {
                timeStamp.StartTime = DTOtimeStamp.StartTime;
                timeStamp.EndTime = DTOtimeStamp.EndTime;
                timeStamp.TaskId = DTOtimeStamp.TaskId;
                timeStamp.EmployeeId = DTOtimeStamp.EmployeeId;
                

                return timeStamp;
            }
            else return null;
        }

        public static List<TimeStampDTO> Map(List<TimeStamp> timeStamps)
        {
            List<TimeStampDTO> retur = new List<TimeStampDTO>();
            foreach (var timeStamp in timeStamps)
            {
                retur.Add(TimeStampMapper.Map(timeStamp));
            }
            return retur;
        }

        public static List<TimeStamp> Map(List<TimeStampDTO> timeStampDTOs)
        {
            List<TimeStamp> retur = new List<TimeStamp>();
            foreach (var timeStampDTO in timeStampDTOs)
            {
                retur.Add(TimeStampMapper.Map(timeStampDTO));
            }
            return retur;
        }

    }
}
