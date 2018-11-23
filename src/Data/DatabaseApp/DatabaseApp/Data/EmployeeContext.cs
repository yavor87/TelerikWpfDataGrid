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

            modelBuilder.Entity<DTO.EmployeeDTO>().HasData(new DTO.EmployeeDTO[]
            {
                new DTO.EmployeeDTO()
                {
                    ID = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Salary = 25000,
                    Department = "Marketing"
                },
                new DTO.EmployeeDTO()
                {
                    ID = 2,
                    FirstName = "Peter",
                    LastName = "Peterson",
                    Salary = 27000,
                    Department = "Marketing"
                },
                new DTO.EmployeeDTO()
                {
                    ID = 3,
                    FirstName = "Mark",
                    LastName = "Harison",
                    Salary = 35000,
                    Department = "Engineering"
                },
                new DTO.EmployeeDTO()
                {
                    ID = 4,
                    FirstName = "David",
                    LastName = "Peterson",
                    Salary = 38000,
                    Department = "Engineering"
                },
                new DTO.EmployeeDTO()
                {
                    ID = 5,
                    FirstName = "Dave",
                    LastName = "Nickleson",
                    Salary = 24000,
                    Department = "Engineering"
                }
            });
        }
    }
}
