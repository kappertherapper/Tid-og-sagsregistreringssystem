using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject.Models;
using DataAccessLayer.Models;

namespace DataTransferObject.Mapper
{
    public static class TimeStampMapper 
    {
        public static TimeStampDTO Map(TimeStamp timeStamp)
        {
            TimeStampDTO DTOtimeStamp = new();
            if (timeStamp != null)
            {
                DTOtimeStamp.StartTime = timeStamp.StartTime;
                DTOtimeStamp.EndTime = timeStamp.EndTime;
                DTOtimeStamp.EmployeeId = timeStamp.EmployeeId;
                DTOtimeStamp.TaskId = timeStamp.TaskId;

                return DTOtimeStamp;
            }
            else return null;
        }

        public static TimeStamp Map(TimeStampDTO DTOtimeStamp)
        {
            TimeStamp timeStamp = new();
            if (DTOtimeStamp != null)
            {
                timeStamp.StartTime = DTOtimeStamp.StartTime;
                timeStamp.EndTime = DTOtimeStamp.EndTime;
                timeStamp.EmployeeId = DTOtimeStamp.EmployeeId;
                timeStamp.TaskId = DTOtimeStamp.TaskId;

                return timeStamp;
            }
            else return null;
        }
    }
}
