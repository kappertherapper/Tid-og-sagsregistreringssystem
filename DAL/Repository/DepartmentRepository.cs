using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Context;
using DAL.Mapper;
using DTO.Models;
using DAL.Models;

namespace DAL.Repository
{
    public class DepartmentRepository
    {
        public static DepartmentDTO GetDepartment(int id)
        {
            using (var context = new SagTidRegisterContext())
            {
                return DepartmentMapper.Map(context.Departments.Find(id));
            }
        }

        public static List<DepartmentDTO> GetAllDepartments()
        {
            using (var context = new SagTidRegisterContext())
            {
                List<Department> retur = new List<Department>();
                retur = context.Departments.ToList();

                return DepartmentMapper.Map(retur);
            }
        }

        public static int AddDepartment(DepartmentDTO department)
        {
            using (var context = new SagTidRegisterContext())
            {
                context.Departments.Add(DepartmentMapper.Map(department));
                context.SaveChanges();
                return department.Id;
            }
        }

        public static void EditDepartment(DepartmentDTO department)
        {
            using (var context = new SagTidRegisterContext())
            {
                Department datadept = context.Departments.Find(department.Id);
                DepartmentMapper.Update(department, datadept);

                context.SaveChanges();
            }
        }
    }
}
