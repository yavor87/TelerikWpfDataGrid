using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseApp.Data
{
    public class EmployeeGenerator
    {
        public EmployeeGenerator()
        {
            _r = new Random();
            _generatedNames = new HashSet<string>();
        }

        private static Lazy<EmployeeGenerator> _instance = new Lazy<EmployeeGenerator>();
        private Random _r;
        private string[] _firstNames = new string[] { "John", "Peter", "Mark", "David", "Dave", "Adam", "Adrian", "Alan", "Alexander", "Andrew", "Anthony", "Austin", "Benjamin", "Blake", "Boris", "Brandon", "Brian", "Cameron", "Carl", "Charles", "Christian", "Christopher", "Colin", "Connor", "Dan", "David", "Dominic", "Dylan", "Edward", "Eric", "Evan", "Frank", "Gavin", "Gordon", "Harry", "Ian", "Isaac", "Jack", "Jacob", "Jake", "James", "Jason", "Joe", "John", "Jonathan", "Joseph", "Joshua", "Julian", "Justin", "Keith", "Kevin", "Leonard", "Liam", "Lucas", "Luke", "Matt", "Max", "Michael", "Nathan", "Neil", "Nicholas", "Oliver", "Owen", "Paul", "Peter", "Phil", "Piers", "Richard", "Robert", "Ryan", "Sam", "Sean", "Sebastian", "Simon", "Stephen", "Steven", "Stewart", "Thomas", "Tim", "Trevor", "Victor", "Warren", "William" };
        private string[] _lastNames = new string[] { "Doe", "Peterson", "Harison", "Nickleson", "Abraham", "Allan", "Alsop", "Anderson", "Arnold", "Avery", "Bailey", "Baker", "Ball", "Bell", "Berry", "Black", "Blake", "Bond", "Bower", "Brown", "Buckland", "Burgess", "Butler", "Cameron", "Campbell", "Carr", "Chapman", "Churchill", "Clark", "Clarkson", "Coleman", "Cornish", "Davidson", "Davies", "Dickens", "Dowd", "Duncan", "Dyer", "Edmunds", "Ellison", "Ferguson", "Fisher", "Forsyth", "Fraser", "Gibson", "Gill", "Glover", "Graham", "Grant", "Gray", "Greene", "Hamilton", "Hardacre", "Harris", "Hart", "Hemmings", "Henderson", "Hill", "Hodges", "Howard", "Hudson", "Hughes", "Hunter", "Ince", "Jackson", "James", "Johnston", "Jones", "Kelly", "Kerr", "King", "Knox", "Lambert", "Langdon", "Lawrence", "Lee", "Lewis", "Lyman", "MacDonald", "Mackay", "Mackenzie", "MacLeod", "Manning", "Marshall", "Martin", "Mathis", "May", "McDonald", "McLean", "McGrath", "Metcalfe", "Miller", "Mills", "Mitchell", "Morgan", "Morrison", "Murray", "Nash", "Newman", "Nolan", "North", "Ogden", "Oliver", "Paige", "Parr", "Parsons", "Paterson", "Payne", "Peake", "Peters", "Piper", "Poole", "Powell", "Pullman", "Quinn", "Rampling", "Randall", "Rees", "Reid", "Roberts", "Robertson", "Ross", "Russell", "Rutherford", "Sanderson", "Scott", "Sharp", "Short", "Simpson", "Skinner", "Slater", "Smith", "Springer", "Stewart", "Sutherland", "Taylor", "Terry", "Thomson", "Tucker", "Turner", "Underwood", "Vance", "Vaughan", "Walker", "Wallace", "Walsh", "Watson", "Welch", "White", "Wilkins", "Wilson", "Wright", "Young" };
        private HashSet<string> _generatedNames;
        private Department[] _departments = new Department[]
        {
            new Department("Engineering", new Position("Engineering Expert", 20000, 30000), new Position("Senior Software Engineer", 45000, 70000), new Position("Junior Software Engineer", 15000, 25000), new Position("Software Engineer", 25000, 45000)),
            new Department("Marketing", new Position("Marketing Expert", 15000, 25000), new Position("Senior Manager", 60000, 250000)),
            new Department("Operations", new Position("Intern", 5000, 15000), new Position("Manager", 60000, 250000)),
        };

        public static EmployeeGenerator Instance => _instance.Value;

        public DTO.EmployeeDTO Generate()
        {
            if (_generatedNames.Count > 20)
                _generatedNames.Remove(_generatedNames.Last());

            Department department = _departments[_r.Next(0, _departments.Length)];
            Position position = department.Positions[_r.Next(0, department.Positions.Length)];

            DTO.EmployeeDTO employee = new DTO.EmployeeDTO();
            do
            {
                employee.FirstName = _firstNames[_r.Next(0, _firstNames.Length)];
                employee.LastName = _lastNames[_r.Next(0, _lastNames.Length)];
            }
            while (_generatedNames.Contains($"{employee.FirstName} {employee.LastName}"));
            _generatedNames.Add($"{employee.FirstName} {employee.LastName}");

            employee.Department = department.Name;
            employee.Salary = _r.Next(position.MinSalary, position.MaxSalary);
            return employee;
        }

        public IEnumerable<DTO.EmployeeDTO> Generate(int number)
        {
            for (int i = 0; i < number; i++)
            {
                yield return Generate();
            }
        }

        private class Department
        {
            public Department(string name, params Position[] positions)
            {
                this.Name = name;
                this.Positions = positions;
            }

            public string Name { get; private set; }
            public Position[] Positions { get; private set; }
        }

        private class Position
        {
            public Position(string name, int minSalary, int maxSalary)
            {
                Name = name;
                MinSalary = minSalary;
                MaxSalary = maxSalary;
            }

            public string Name { get; private set; }
            public int MinSalary { get; private set; }
            public int MaxSalary { get; private set; }
        }
    }
}
