using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Mapper;
using DAL.Models;
using DTO.Models;

namespace DAL.Repository
{
    public static class TimeStampRepository
    {
        public static TimeStampDTO GetTimeStamp(int id)
        {
            using (var context = new SagTidRegisterContext())
            {
                return TimeStampMapper.Map(context.TimeStamps.Find(id));
            }
        }

        public static void AddTimeStamp(TimeStampDTO timeStamp)
        {
            using (var context = new SagTidRegisterContext())
            {
                context.TimeStamps.Add(TimeStampMapper.Map(timeStamp));
                context.SaveChanges();
            }
        }

        public static List<TimeStampDTO> GetAllTimeStamps()
        {
            using (var context = new SagTidRegisterContext())
            {
                var retur = context.TimeStamps.ToList();
                return TimeStampMapper.Map(retur);
            }
        }

        public static List<TimeStampDTO> GetAllTimeStampsOnEmployee(int id)
        {
            using (var context = new SagTidRegisterContext())
            {
                var retur = context.TimeStamps.Where(t => t.EmployeeId == id).ToList();
                return TimeStampMapper.Map(retur);
            }
        }
    }
}
