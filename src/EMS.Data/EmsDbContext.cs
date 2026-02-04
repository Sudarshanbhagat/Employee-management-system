using Microsoft.EntityFrameworkCore;
using EMS.Data.Models;

namespace EMS.Data
{
    public class EmsDbContext : DbContext
    {
        public EmsDbContext(DbContextOptions<EmsDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<LeaveRequest> LeaveRequests { get; set; } = null!;
        public DbSet<LeaveType> LeaveTypes { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<AuditLog> AuditLogs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin", Description = "Administrator", CreatedAt = DateTime.UtcNow },
                new Role { Id = 2, Name = "HR", Description = "HR Manager", CreatedAt = DateTime.UtcNow },
                new Role { Id = 3, Name = "Manager", Description = "Project Manager", CreatedAt = DateTime.UtcNow },
                new Role { Id = 4, Name = "Employee", Description = "Regular Employee", CreatedAt = DateTime.UtcNow }
            );

            // Seed Leave Types
            modelBuilder.Entity<LeaveType>().HasData(
                new LeaveType { Id = 1, Name = "Sick Leave", DaysAllowed = 10, IsActive = true, CreatedAt = DateTime.UtcNow },
                new LeaveType { Id = 2, Name = "Vacation", DaysAllowed = 20, IsActive = true, CreatedAt = DateTime.UtcNow },
                new LeaveType { Id = 3, Name = "Personal Leave", DaysAllowed = 5, IsActive = true, CreatedAt = DateTime.UtcNow },
                new LeaveType { Id = 4, Name = "Maternity Leave", DaysAllowed = 180, IsActive = true, CreatedAt = DateTime.UtcNow }
            );

            // Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "IT", Description = "Information Technology", Budget = 500000, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department { Id = 2, Name = "HR", Description = "Human Resources", Budget = 200000, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Department { Id = 3, Name = "Finance", Description = "Finance & Accounting", Budget = 300000, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );

            // Configure Relationships
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Role)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Department)
                .WithMany()
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.CreatedBy)
                .WithMany(e => e.Projects)
                .HasForeignKey(p => p.CreatedByEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(l => l.Employee)
                .WithMany(e => e.LeaveRequests)
                .HasForeignKey(l => l.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(l => l.LeaveType)
                .WithMany(lt => lt.LeaveRequests)
                .HasForeignKey(l => l.LeaveTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Employee)
                .WithMany()
                .HasForeignKey(u => u.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AuditLog>()
                .HasOne(a => a.ChangedByEmployee)
                .WithMany(e => e.AuditLogs)
                .HasForeignKey(a => a.ChangedByEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
