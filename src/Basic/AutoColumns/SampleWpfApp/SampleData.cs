using System.ComponentModel.DataAnnotations;

namespace SampleWpfApp
{
    public class Employee
    {
        [Display(AutoGenerateField = false)]
        public string FirstName { get; set; }

        [Display(AutoGenerateField = false)]
        public string LastName { get; set; }

        [Display(AutoGenerateField = false)]
        public decimal Salary { get; set; }

        [Display(Order = 2)]
        public string Department { get; set; }

        [Display(Name = "Name", Order = 1)]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Salary", Order = 3)]
        public string FormattedSalary => this.Salary.ToString("C");
    }

    public class SampleData
    {
        public static Employee[] Employees => new Employee[]
        {
            new Employee()
            {
                FirstName = "John",
                LastName = "Doe",
                Salary = 25000,
                Department = "Marketing"
            },
            new Employee()
            {
                FirstName = "Peter",
                LastName = "Peterson",
                Salary = 27000,
                Department = "Marketing"
            },
            new Employee()
            {
                FirstName = "Mark",
                LastName = "Harison",
                Salary = 35000,
                Department = "Engineering"
            },
            new Employee()
            {
                FirstName = "David",
                LastName = "Peterson",
                Salary = 38000,
                Department = "Engineering"
            },
            new Employee()
            {
                FirstName = "Dave",
                LastName = "Nickleson",
                Salary = 24000,
                Department = "Engineering"
            }
        };
    }
}
