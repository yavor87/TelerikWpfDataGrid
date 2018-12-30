using DatabaseApp.Model;
using DatabaseApp.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.VirtualGrid;

namespace DatabaseApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            
            this.EmployeesProvider = new EmployeeProvider(_employeeService.GetEmployees());
        }

        public MainViewModel()
            : this(new EmployeeService())
        { }

        private IEmployeeService _employeeService;
        private Telerik.Windows.Controls.VirtualGrid.DataProvider employees;

        public Telerik.Windows.Controls.VirtualGrid.DataProvider EmployeesProvider
        {
            get => this.employees;
            private set
            {
                this.employees = value;
                RaisePropertyChanged();
            }
        }
    }

    public class EmployeeProvider : Telerik.Windows.Controls.VirtualGrid.DataProvider
    {
        public EmployeeProvider(IQueryable<Model.Employee> employees)
            : base(employees)
        {
        }

        public override IList<ItemPropertyInfo> ItemProperties
        {
            get
            {
                return new List<ItemPropertyInfo>()
                {
                    base.ItemProperties.Single(c => c.Name == nameof(Employee.FullName)),
                    base.ItemProperties.Single(c => c.Name == nameof(Employee.Department)),
                    base.ItemProperties.Single(c => c.Name == nameof(Employee.Salary))
                };
            }
        }

        protected override void OnCellValueNeeded(CellValueEventArgs valueEventArgs)
        {
            base.OnCellValueNeeded(valueEventArgs);

            if (valueEventArgs.ColumnIndex == 2)
            {
                valueEventArgs.Value = string.Format("{0:C2}", valueEventArgs.Value);
            }
        }
    }
}
