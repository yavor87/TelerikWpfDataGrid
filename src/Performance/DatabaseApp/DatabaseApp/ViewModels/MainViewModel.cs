using DatabaseApp.Model;
using DatabaseApp.Services;
using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls;

namespace DatabaseApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;

            //this.Employees = _employeeService.GetEmployees();
            this.Employees = new Telerik.Windows.Data.VirtualQueryableCollectionView(_employeeService.GetEmployees()) { LoadSize = 20 };
        }

        public MainViewModel()
            : this(new EmployeeService())
        { }

        private IEmployeeService _employeeService;
        private Telerik.Windows.Data.VirtualQueryableCollectionView employees;

        public Telerik.Windows.Data.VirtualQueryableCollectionView Employees
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
