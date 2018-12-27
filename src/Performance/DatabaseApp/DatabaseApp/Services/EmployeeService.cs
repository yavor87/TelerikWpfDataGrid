using AutoMapper.QueryableExtensions;
using DatabaseApp.Data;
using DatabaseApp.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseApp.Services
{
    public interface IEmployeeService
    {
        IQueryable<Model.Employee> GetEmployees();
    }

    public class EmployeeService : IEmployeeService
    {
        public EmployeeService()
        {
            _context = new EmployeeContext();
            _context.Database.Migrate();
            if (!_context.Employees.Any())
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    System.Diagnostics.Debug.WriteLine("Sample data generation started.");
                    var generator = new EmployeeGenerator();
                    int cnt = 0;
                    int total = 1 * 1000 * 1000;
                    List<Data.DTO.EmployeeDTO> cache = new List<Data.DTO.EmployeeDTO>(10000);
                    foreach (var item in generator.Generate(total))
                    {
                        cache.Add(item);
                        cnt++;
                        if (cnt % 10000 == 0)
                        {
                            _context.Employees.AddRange(cache);
                            _context.SaveChanges();
                            cache.Clear();
                            System.Diagnostics.Debug.WriteLine($"Sample data generation {(cnt * 1.0) / total:P2}");
                        }
                    }

                    transaction.Commit();
                    System.Diagnostics.Debug.WriteLine("Sample data generation completed.");
                }
            }
        }

        private EmployeeContext _context;

        public IQueryable<Model.Employee> GetEmployees()
        {
            return _context.Employees.ProjectTo<Model.Employee>();
        }
    }
}
