using System.Windows;

namespace DatabaseApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // AutoMapper configuration
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Data.DTO.EmployeeDTO, Model.Employee>()
                .ForMember(c => c.FullName, opt => opt.MapFrom(c => $"{c.FirstName} {c.LastName}")));
        }
    }
}
