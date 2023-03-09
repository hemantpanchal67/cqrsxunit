using CQRSMediatR.Data;
using CQRSMediatR.Entities;
using CQRSMediatR.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CQRSMediatR.Repository
{
    public class EmployeeRepository : IEmployeeRepository    
    {
        
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Employee> _dbSet;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Employees;
        }

        public async Task<EntityEntry<Employee>> Create(Employee employee) => await _context.Employees.AddAsync(employee);

        public async Task<Employee> Find(long id) => await _dbSet.FindAsync(id);

        public async Task<Employee> FindOrThrow(long id) => await Find(id) ?? throw new Exception("Employee not found.");

        public async Task<int> Flush() => await _context.SaveChangesAsync();

        public async Task<List<Employee>> GetAllAsync() => await _dbSet.ToListAsync();

        public async void Remove(Employee employee) => _context.Employees.Remove(employee);

        public async void Update(Employee employee) => _context.Employees.Update(employee);
    }
}
