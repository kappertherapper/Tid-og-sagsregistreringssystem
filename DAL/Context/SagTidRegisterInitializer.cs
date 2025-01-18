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
            // departments
            var department = context.Departments.Add(new Department() { Id = 1, Name = "Den", Number = 5 });
            var department1 = context.Departments.Add(new Department() { Id = 2, Name = "HR", Number = 10 });
            var department2 = context.Departments.Add(new Department() { Id = 3, Name = "IT", Number = 15 });
            var department3 = context.Departments.Add(new Department() { Id = 4, Name = "Finance", Number = 20 });

            // employees
            var employee = context.Employees.Add(new Employee() { Id = 1, Cpr = "6234-7823", Department = department, DepartmentId = 1, Name = "Henne" });
            var employee1 = context.Employees.Add(new Employee() { Id = 2, Cpr = "1234-5678", Department = department1, DepartmentId = 2, Name = "John Doe" });
            var employee2 = context.Employees.Add(new Employee() { Id = 3, Cpr = "2345-6789", Department = department1, DepartmentId = 2, Name = "Jane Smith" });
            var employee3 = context.Employees.Add(new Employee() { Id = 4, Cpr = "3456-7890", Department = department2, DepartmentId = 3, Name = "Alice Brown" });
            var employee4 = context.Employees.Add(new Employee() { Id = 5, Cpr = "4567-8901", Department = department3, DepartmentId = 4, Name = "Bob White" });

            // tasks
            var task = context.TaskManagers.Add(new TaskManager() { Id = 1, Department = department, DepartmentId = 1, Description = "wauuuuw", TaskNumber = 1, Title = "hold da hel op" });
            var task1 = context.TaskManagers.Add(new TaskManager() { Id = 2, Department = department1, DepartmentId = 2, Description = "Plan company event", TaskNumber = 2, Title = "Event Planning" });
            var task2 = context.TaskManagers.Add(new TaskManager() { Id = 3, Department = department2, DepartmentId = 3, Description = "Upgrade server", TaskNumber = 3, Title = "Server Upgrade" });
            var task3 = context.TaskManagers.Add(new TaskManager() { Id = 4, Department = department3, DepartmentId = 4, Description = "Prepare budget report", TaskNumber = 4, Title = "Budget Preparation" });
            var task4 = context.TaskManagers.Add(new TaskManager() { Id = 5, Department = department1, DepartmentId = 2, Description = "Conduct interviews", TaskNumber = 5, Title = "Recruitment" });

            // Save
            context.SaveChanges();
        } 
    }
}
