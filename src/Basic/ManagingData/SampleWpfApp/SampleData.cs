using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleWpfApp
{
    public class Employee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public string Department { get; set; }

        public string Position { get; set; }
    }

    public class SampleData
    {
        private static Lazy<string[]> _employeePositions = new Lazy<string[]>(() => Employees.Select(c => c.Position).Distinct().ToArray());
        private static Lazy<string[]> _employeeDepartments = new Lazy<string[]>(() => Employees.Select(c => c.Department).Distinct().ToArray());

        public static string[] EmployeePositions => _employeePositions.Value;
        public static string[] EmployeeDepartments => _employeeDepartments.Value;

        public static ICollection<Employee> Employees => new List<Employee>
        {
            new Employee()
            {
                FirstName = "John",
                LastName = "Doe",
                Salary = 25000,
                Department = "Marketing",
                Position = "Marketing Expert"
            },
            new Employee()
            {
                FirstName = "Peter",
                LastName = "Peterson",
                Salary = 27000,
                Department = "Marketing",
                Position = "Manager"
            },
            new Employee()
            {
                FirstName = "Mark",
                LastName = "Harison",
                Salary = 35000,
                Department = "Engineering",
                Position = "Senior Software Engineer"
            },
            new Employee()
            {
                FirstName = "David",
                LastName = "Peterson",
                Salary = 38000,
                Department = "Engineering",
                Position = "Senior Software Engineer"
            },
            new Employee()
            {
                FirstName = "Dave",
                LastName = "Nickleson",
                Salary = 24000,
                Department = "Engineering",
                Position = "Junior Software Engineer"
            }
        };
    }
}
