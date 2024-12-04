﻿using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Context;
using DataAccessLayer.Mapper;
using DataTransferObject.Models;
namespace DataAccessLayer.Repository
{
    public class EmployeeRepository
    {
        public static EmployeeDTO GetEmployee(int id)
        {
            using SagTidRegisterContext context = new SagTidRegisterContext();
            return EmployeeMapper.Map(context.Employees.Find(id));
        }

        public static List<EmployeeDTO> GetAllEmployees(int id)
        {
            using SagTidRegisterContext context = new SagTidRegisterContext();

            List<EmployeeDTO> employeeDTOs = context.Employees
                .Where(e => e.Id == id)
                .Select(e => new EmployeeDTO
                {
                    Id = e.Id,
                    Name = e.Name,
                }).ToList();

            return employeeDTOs;
            
        }

        public static int AddEmployee(EmployeeDTO employee)
        {
            using SagTidRegisterContext context = new SagTidRegisterContext();
            context.Employees.Add(EmployeeMapper.Map(employee));
            context.SaveChanges();
            return employee.Id;
        }

        public static void EditEmployee(EmployeeDTO employee)
        {
            using SagTidRegisterContext context = new SagTidRegisterContext();
            DataAccessLayer.Models.Employee dataemp = context.Employees.Find(employee.Id);
            EmployeeMapper.Update(employee, dataemp);

            context.SaveChanges();
        }
    }
}