using System;
using System.Data;
using System.Linq;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace SampleWpfApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            _r = new Random();
            _refreshDataCommand = new DelegateCommand(this.RefreshData);
            _data = GetSampleView();
        }

        private DataView _data;
        private DelegateCommand _refreshDataCommand;
        private Random _r;

        public ICommand RefreshDataCommand => _refreshDataCommand;

        public DataView Data
        {
            get => _data;
            set
            {
                if (_data == value)
                    return;

                _data = value;
                this.RaisePropertyChanged();
            }
        }

        private void RefreshData(object obj)
        {
            this.Data = this.GenerateRandomData();
        }

        private DataView GenerateRandomData()
        {
            DataTable table = new DataTable();
            table.Columns.AddRange(Enumerable.Range(0, _r.Next(3, 10))
                .Select(c => new DataColumn($"Column {c + 1}", typeof(int)))
                .ToArray());

            for (int i = 0; i < 10; i++)
            {
                table.Rows.Add(Enumerable.Range(0, table.Columns.Count)
                    .Select(c => (object)_r.Next(0, 100)).ToArray());
            }
            return table.DefaultView;
        }

        static DataView GetSampleView()
        {
            //
            // Here we create a DataTable with four columns.
            //
            DataTable table = new DataTable();
            table.Columns.Add("Weight", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Breed", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));

            //
            // Here we add unsorted data to the DataTable and return.
            //
            table.Rows.Add(57, "Koko", "Shar Pei", DateTime.Now);
            table.Rows.Add(130, "Fido", "Bullmastiff", DateTime.Now);
            table.Rows.Add(92, "Alex", "Anatolian Shepherd Dog", DateTime.Now);
            table.Rows.Add(25, "Charles", "Cavalier King Charles Spaniel", DateTime.Now);
            table.Rows.Add(7, "Candy", "Yorkshire Terrier", DateTime.Now);
            return table.DefaultView;
        }
    }
}
