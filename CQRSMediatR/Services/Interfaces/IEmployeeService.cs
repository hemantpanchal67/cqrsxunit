using CQRSMediatR.Dto;
using CQRSMediatR.Entities;

namespace CQRSMediatR.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> Create(EmployeeDto dto);
        Task Update(Employee employee, EmployeeDto dto);
        Task Remove(Employee employee);
    }
}
