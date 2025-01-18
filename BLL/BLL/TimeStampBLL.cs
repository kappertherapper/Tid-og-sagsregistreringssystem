using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using DTO.Models;

namespace BLL.BLL
{
    public class TimeStampBLL
    {
        public TimeStampBLL() { }

        public TimeStampDTO GetTimeStamp(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return TimeStampRepository.GetTimeStamp(id);
        }

        public static void AddTimeStamp(TimeStampDTO timeStamp)
        {
            if (timeStamp == null) throw new ArgumentNullException();
            TimeStampRepository.AddTimeStamp(timeStamp);
        }

        public static List<TimeStampDTO> GetAllTimeStamps()
        {
            return TimeStampRepository.GetAllTimeStamps();
        }

        public static List<TimeStampDTO> GetAllTimeStamps(int id)
        {
            return TimeStampRepository.GetAllTimeStamps();
        }

        public static List<TimeStampDTO> GetAllTimeStampsByEmployee(int id)
        {
            return TimeStampRepository.GetAllTimeStampsOnEmployee(id);
        }
    }
}
