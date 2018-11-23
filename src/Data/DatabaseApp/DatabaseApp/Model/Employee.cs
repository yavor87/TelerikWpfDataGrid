using System.ComponentModel.DataAnnotations;

namespace DatabaseApp.Model
{
    public class Employee
    {
        public Employee(int id)
        {
            this.ID = id;
        }

        [Display(AutoGenerateField = false)]
        public int ID { get; }

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
}
