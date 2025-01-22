using System.Collections.Generic;
using System.Linq;
using DAL.Context;
using DAL.Mapper;
using DTO.Models;
using DAL.Models;
using System;

namespace DAL.Repository
{
    public static class EmployeeRepository
    {
        public static EmployeeDTO GetEmployee(int id)
        {
            using (var context = new SagTidRegisterContext())
            {
                return EmployeeMapper.Map(context.Employees.Find(id));
            }
        }

        public static List<EmployeeDTO> GetAllEmployeesByDepartment(int id)
        {
            using (var context = new SagTidRegisterContext())
            {
                var retur = context.Employees.Where(e => e.DepartmentId == id).ToList();

                return EmployeeMapper.Map(retur);
            }
        }

        public static List<EmployeeDTO> GetAllEmployees()
        {
            using (var context = new SagTidRegisterContext())
            {
                var retur = new List<Employee>();
                retur = context.Employees.ToList();

                return EmployeeMapper.Map(retur);
            }
        }

        public static void AddEmployee(EmployeeDTO employee)
        {
            using (var context = new SagTidRegisterContext())
            {
                context.Employees.Add(EmployeeMapper.Map(employee));
                context.SaveChanges();
            }
                
        }

        public static void EditEmployee(EmployeeDTO employee)
        {
            using (var context = new SagTidRegisterContext())
            {
                var dataemp = context.Employees.Find(employee.Id);
                EmployeeMapper.Update(employee, dataemp);

                context.SaveChanges();
            }
        }

        public static double GetTotalWorkTime(int id)
        {
            using (var context = new SagTidRegisterContext())
            {
                return context.TimeStamps
                    .Where(t => t.EmployeeId == id)
                    .ToList().Sum(t => (t.EndTime - t.StartTime).TotalHours);
            }
        }
    }
}
