using DatabaseApp.Model;
using DatabaseApp.Services;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace DatabaseApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _employeeService.GetEmployeesAsync()
                .ContinueWith(antc => Employees = antc.Result, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public MainViewModel()
            : this(new EmployeeService())
        { }

        private IEmployeeService _employeeService;
        private Employee[] employees;

        public Employee[] Employees
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
