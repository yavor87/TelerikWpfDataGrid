using Microsoft.EntityFrameworkCore;

namespace DatabaseApp.Data
{
    public class EmployeeContext : DbContext
    {
        public virtual DbSet<DTO.EmployeeDTO> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!System.IO.Directory.Exists("Data"))
                System.IO.Directory.CreateDirectory("Data");
            optionsBuilder.UseSqlite("Data Source=\"Data\\employees.db\"");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Data.DTO.EmployeeDTO>()
                .HasIndex(c => c.Department);

            modelBuilder.Entity<Data.DTO.EmployeeDTO>()
                .HasIndex(c => c.Salary);
        }
    }
}
