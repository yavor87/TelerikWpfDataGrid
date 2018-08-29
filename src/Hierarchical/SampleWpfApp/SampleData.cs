namespace SampleWpfApp
{
    public class Employee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public string Department { get; set; }

        public string Position { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public bool IsExpandable => this.ResponsibleFor != null;

        public Employee[] ResponsibleFor { get; set; }
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
                Department = "Marketing",
                Position = "Marketing Expert"
            },
            new Employee()
            {
                FirstName = "Peter",
                LastName = "Peterson",
                Salary = 27000,
                Department = "Marketing",
                Position = "Manager",
                ResponsibleFor = new Employee[]
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
                        FirstName = "Anna",
                        LastName = "Butler",
                        Salary = 25700,
                        Department = "Marketing",
                        Position = "Marketing Expert"
                    }
                }
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
                FirstName = "Dominic",
                LastName = "Gibson",
                Salary = 37000,
                Department = "Engineering",
                Position = "Team Leader",
                ResponsibleFor = new Employee[]
                {
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
                }
            },
        };
    }
}
