using DatabaseApp.Model;
using DatabaseApp.Services;
using System.Linq;
using Telerik.Windows.Controls;

namespace DatabaseApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            this.Employees = _employeeService.GetEmployees();
        }

        public MainViewModel()
            : this(new EmployeeService())
        { }

        private IEmployeeService _employeeService;
        private IQueryable<Employee> employees;

        public IQueryable<Employee> Employees
        {
            get => this.employees;
            private set
            {
                this.employees = value;
                RaisePropertyChanged();
            }
        }
    }
}
