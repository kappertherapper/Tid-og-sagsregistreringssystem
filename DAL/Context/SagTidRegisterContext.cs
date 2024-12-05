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
        public DbSet<Company> Companys { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskManager> Tasks { get; set; }
        public DbSet<TimeStamp> TimeStamps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Company -> Department (One-to-Many)
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Departments)
                .WithRequired(d => d.Company)
                .HasForeignKey(d => d.CompanyId);

            // Department -> Employees (One-to-Many)
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DepartmentId);

            // Department -> Task (One-to-Many)
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Tasks)
                .WithRequired(t => t.Department)
                .HasForeignKey(t => t.DepartmentId);

            // Task -> TimeStamps (One-to-Many)
            modelBuilder.Entity<TaskManager>()
                .HasMany(t => t.TimeStamps)
                .WithRequired(ts => ts.Task)
                .HasForeignKey(ts => ts.TaskId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>().ToTable("Companies");
            modelBuilder.Entity<Department>().ToTable("Departments");
            modelBuilder.Entity<TaskManager>().ToTable("Tasks");
            modelBuilder.Entity<TimeStamp>().ToTable("TimeStamps");
        }
    }
}
