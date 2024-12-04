using System.Data.Entity;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Context
{
    public class SagTidRegisterContext :DbContext
    {
        public SagTidRegisterContext() : base("SagTidRegisterDB")
        {
            
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
                .HasForeignKey(d => d.Company.Id);

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

            modelBuilder.Entity<Company>().ToTable("Companies");
            modelBuilder.Entity<Department>().ToTable("Departments");
            modelBuilder.Entity<Task>().ToTable("Tasks");
        }
    }
}
