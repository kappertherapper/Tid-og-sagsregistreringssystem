using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repository
{
    public class EmployeeRepository
    {
        public static Employee getEmployee(int id)
        {
            using SagTidRegisterContext context = new SagTidRegisterContext();
            return EmployeeMapper.Map(context.Employees.Find(id));
        }
    }
}
