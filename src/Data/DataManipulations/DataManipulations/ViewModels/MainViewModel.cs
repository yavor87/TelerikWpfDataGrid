using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace DataManipulations.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            _data = new ObservableCollection<Employee>(SampleData.Employees);
            _dataView = new QueryableCollectionView(_data);
            _dataView.GroupDescriptors.CollectionChanged += OnGroupDescriptorsChanged;

            AddNewItemCommand = new DelegateCommand(OnAddNewItem);
            RemoveLastItemCommand = new DelegateCommand(OnRemoveLastItem);
            SortDataCommand = new DelegateCommand(OnSortData);
            FilterDataCommand = new DelegateCommand(OnFilterData);
            GroupDataCommand = new DelegateCommand(OnGroupData);
        }

        private ObservableCollection<Employee> _data;
        private QueryableCollectionView _dataView;

        public ICommand AddNewItemCommand { get; }
        public ICommand RemoveLastItemCommand { get; }
        public ICommand SortDataCommand { get; }
        public ICommand FilterDataCommand { get; }
        public ICommand GroupDataCommand { get; }

        public QueryableCollectionView Data => _dataView;

        private void OnAddNewItem(object obj)
        {
            _data.Add(EmployeeGenerator.Instance.Generate());
        }

        private void OnRemoveLastItem(object obj)
        {
            if (_data.Count == 0)
                return;

            _data.RemoveAt(_data.Count - 1);
        }

        private void OnSortData(object obj)
        {
            if (_dataView.SortDescriptors.Count != 0)
            {
                _dataView.SortDescriptors.Clear();
            }
            else
            {
                _dataView.SortDescriptors.Add(new SortDescriptor() { Member = nameof(Employee.LastName), SortDirection = System.ComponentModel.ListSortDirection.Descending });
            }
        }

        private void OnFilterData(object obj)
        {
            if (_dataView.FilterDescriptors.Count != 0)
            {
                _dataView.FilterDescriptors.Clear();
            }
            else
            {
                _dataView.FilterDescriptors.Add(new FilterDescriptor(nameof(Employee.LastName), FilterOperator.StartsWith, "P"));
            }
        }

        private void OnGroupData(object obj)
        {
            if (_dataView.GroupDescriptors.Count != 0)
            {
                _dataView.GroupDescriptors.Clear();
            }
            else
            {
                _dataView.GroupDescriptors.Add(new GroupDescriptor() { Member = nameof(Employee.Department) });
            }
        }

        private void OnGroupDescriptorsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Group descriptor {e.Action}");
        }
    }
}
