using AutoMapper.QueryableExtensions;
using DatabaseApp.Data;
using DatabaseApp.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DatabaseApp.Services
{
    public interface IEmployeeService
    {
        IQueryable<Employee> GetEmployees();
    }

    public class EmployeeService : IEmployeeService
    {
        public EmployeeService()
        {
            _context = new EmployeeContext();
            _context.Database.Migrate();
        }

        private EmployeeContext _context;

        public IQueryable<Employee> GetEmployees()
        {
            return _context.Employees.ProjectTo<Model.Employee>();
        }
    }
}
