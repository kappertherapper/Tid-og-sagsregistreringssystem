using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Context
{
    public class SagTidRegisterInitializer : CreateDatabaseIfNotExists<SagTidRegisterContext>
    {
        protected override void Seed(SagTidRegisterContext context)
        {
            // Creating a company
            var company = context.Companys.Add(new Company("Sejt bygning"));

            // Creating departments and associating them with the company
            var department1 = context.Departments.Add(new Department("undersøgelse", company, 1));
            var department2 = context.Departments.Add(new Department("biologisk", company, 2));
            var department3 = context.Departments.Add(new Department("kateofask", company, 3));

            // Creating employees and assigning them to departments
            var employee1 = context.Employees.Add(new Employee("Anders", "110795-5566"));
            var employee2 = context.Employees.Add(new Employee("Noller", "160288-2776"));
            var employee3 = context.Employees.Add(new Employee("Flemming", "110795-5786"));

            employee1.AssignDepartment(department1);
            employee2.AssignDepartment(department2);
            employee3.AssignDepartment(department3);

            // Creating tasks and associating them with departments
            var task1 = context.Tasks.Add(new TaskManager("help", 1, "bare gøre det"));
            var task2 = context.Tasks.Add(new TaskManager("hæfghlp", 2, "ja gsdføre det"));
            var task3 = context.Tasks.Add(new TaskManager("dfg", 3, "ja gøre det"));
            var task4 = context.Tasks.Add(new TaskManager("hældfgp", 4, "ja gøre det"));
            var task5 = context.Tasks.Add(new TaskManager("hæfghlp", 5, "ja gøre det"));

            task1.AssignDepartment(department1);
            task2.AssignDepartment(department2);
            task3.AssignDepartment(department3);
            task4.AssignDepartment(department1);
            task5.AssignDepartment(department1);

            // Save changes to persist data to the database
            context.SaveChanges();
        } 
    }
}
