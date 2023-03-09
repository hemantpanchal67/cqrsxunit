using CQRSMediatR.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CQRSMediatR.Repository.Generic
{
    public interface IEmployeeRepository
    {
        Task<Employee> Find(long id);
        Task<Employee> FindOrThrow(long id);
        Task<List<Employee>> GetAllAsync();
        Task<EntityEntry<Employee>> Create(Employee request);
        void Update(Employee employee);
        Task<int> Flush();
        public void Remove(Employee employee);
    }
}
