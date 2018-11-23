using DatabaseApp.Data;
using DatabaseApp.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseApp.Services
{
    public interface IEmployeeService
    {
        Task<Employee[]> GetEmployeesAsync();
    }

    public class EmployeeService : IEmployeeService
    {
        public EmployeeService()
        {
            _context = new EmployeeContext();
            _context.Database.Migrate();
        }

        private EmployeeContext _context;

        public Task<Employee[]> GetEmployeesAsync()
        {
            var query = _context.Employees.ToAsyncEnumerable().Select(c => DomainMapper.ToModel(c));
            return query.ToArray();
        }
    }
}
