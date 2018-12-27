namespace DatabaseApp.Model
{
    public class Employee
    {
        public Employee(int id)
        {
            this.ID = id;
        }

        public int ID { get; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public string Department { get; set; }

        public string FullName { get; set; }
    }
}
