using System.Collections.Generic;
using System.Linq;
using DAL.Context;
using DAL.Mapper;
using DTO.Models;

namespace DAL.Repository
{
    public class EmployeeRepository
    {
        public static EmployeeDTO GetEmployee(int id)
        {
            using (var context = new SagTidRegisterContext())
            {
                return EmployeeMapper.Map(context.Employees.Find(id));
            }
        }

        public static List<EmployeeDTO> GetAllEmployees()
        {
            using (var context = new SagTidRegisterContext())
            {
                List<EmployeeDTO> employeeDTOs = context.Employees
                .Select(e => new EmployeeDTO
                {
                    Id = e.Id,
                    Name = e.Name,
                }).ToList();

                return employeeDTOs;
            }
        }

        public static int AddEmployee(EmployeeDTO employee)
        {
            using (var context = new SagTidRegisterContext())
            {
                context.Employees.Add(EmployeeMapper.Map(employee));
                context.SaveChanges();
                return employee.Id;
            }
                
        }

        public static void EditEmployee(EmployeeDTO employee)
        {
            using (var context = new SagTidRegisterContext())
            {
                Models.Employee dataemp = context.Employees.Find(employee.Id);
                EmployeeMapper.Update(employee, dataemp);

                context.SaveChanges();
            }
        }
    }
}
