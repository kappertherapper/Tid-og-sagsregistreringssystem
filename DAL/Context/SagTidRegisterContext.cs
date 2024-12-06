using System;
using System.Data.Entity;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Context
{
    public class SagTidRegisterContext :DbContext
    {
        public SagTidRegisterContext() : base("SagTidRegisterDB")
        {
            Database.Log = Console.WriteLine;
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskManager> TaskManagers { get; set; }
        public DbSet<TimeStamp> TimeStamps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Employee - Department (Many-to-One)
            modelBuilder.Entity<Employee>()
                .HasOptional(e => e.Department)
                .WithMany()
                .HasForeignKey(e => e.DepartmentId)
                .WillCascadeOnDelete(false);

            // TaskManager - Department (Many-to-One)
            modelBuilder.Entity<TaskManager>()
                .HasRequired(tm => tm.Department)
                .WithMany()
                .HasForeignKey(tm => tm.DepartmentId)
                .WillCascadeOnDelete(false);

            // TimeStamp - TaskManager (Many-to-One)
            modelBuilder.Entity<TimeStamp>()
                .HasRequired(ts => ts.Task)
                .WithMany(t => t.TimeStamps)
                .HasForeignKey(ts => ts.TaskId)
                .WillCascadeOnDelete(false);

            // TimeStamp - Employee (Many-to-One)
            modelBuilder.Entity<TimeStamp>()
                .HasRequired(ts => ts.Employee)
                .WithMany()
                .HasForeignKey(ts => ts.EmployeeId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
