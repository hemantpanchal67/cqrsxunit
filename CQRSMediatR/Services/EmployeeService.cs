using CQRSMediatR.Dto;
using CQRSMediatR.Entities;
using CQRSMediatR.Repository.Generic;
using CQRSMediatR.Services.Interfaces;

namespace CQRSMediatR.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee> Create(EmployeeDto dto)
        {
            var employee = new Employee(dto.FirstName, dto.LastName, dto.Address, dto.Phone, dto.Salary);
            await _employeeRepository.Create(employee);
            await _employeeRepository.Flush();
            return employee;
        }

        public async Task Remove(Employee employee)
        {
            _employeeRepository.Remove(employee);
            await _employeeRepository.Flush();
        }

        public async Task Update(Employee employee, EmployeeDto dto)
        {
            employee.Update(dto.FirstName, dto.LastName, dto.Address, dto.Phone, dto.Salary);
            _employeeRepository.Update(employee);
            await _employeeRepository.Flush();
        }
    }
}
