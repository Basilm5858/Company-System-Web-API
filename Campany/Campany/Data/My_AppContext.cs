using Campany.Models;
using Microsoft.EntityFrameworkCore;

namespace Campany.Data
{
    public class My_AppContext : DbContext
    {
        public My_AppContext(DbContextOptions<My_AppContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(x => x.Department)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(x => x.Project)
                .WithMany(x => x.EmployeeProjects)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.EmployeeProjects)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Project>()
               .HasOne(x => x.Department)
               .WithMany(x => x.Projects)
               .HasForeignKey(x => x.DepartmentId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeProject>().HasIndex(x => new { x.ProjectId, x.EmployeeId }).IsUnique();

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = 1, Email = "Basil@gmail.com", Name = "Basil", Password = "123456", Role = "Admin" });

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "IT", Location = "Cairo" },
                new Department { Id = 2, Name = "HR", Location = "Alexandria" }
            );

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Name = "E-Commerce Platform",
                    Description = "Building an online shopping platform",
                    StartDate = new DateTime(2026, 1, 1),
                    Budget = 50000m,
                    DepartmentId = 1
                },
                new Project
                {
                    Id = 2,
                    Name = "Recruitment System",
                    Description = "Internal HR tracking system",
                    StartDate = new DateTime(2026, 3, 1),
                    Budget = 20000m,
                    DepartmentId = 2
                }
            );

           
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FullName = "Ahmed Ali",
                    Email = "ahmed.ali@company.com",
                    Salary = 15000m,
                    HireDate = new DateTime(2025, 5, 10),
                    DepartmentId = 1
                },
                new Employee
                {
                    Id = 2,
                    FullName = "Sara Mohamed",
                    Email = "sara.mohamed@company.com",
                    Salary = 12000m,
                    HireDate = new DateTime(2025, 8, 15),
                    DepartmentId = 2
                }
            );

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 1,
                    EmployeeId = 1,
                    ProjectId = 1,
                    AssignedRole = "Backend Developer",
                    AssignedDate = new DateTime(2026, 1, 5)
                },
                new EmployeeProject
                {
                    Id = 2,
                    EmployeeId = 2,
                    ProjectId = 2,
                    AssignedRole = "HR Coordinator",
                    AssignedDate = new DateTime(2026, 3, 5)
                }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
