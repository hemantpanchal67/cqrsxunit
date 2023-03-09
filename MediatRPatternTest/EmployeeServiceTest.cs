using CQRSMediatR.Dto;
using CQRSMediatR.Entities;
using CQRSMediatR.Repository.Generic;
using CQRSMediatR.Services;
using Moq;

namespace MediatRPatternTest
{
    public class EmployeeServiceTest
    {
        private readonly EmployeeService _employeeService;
        private readonly IEmployeeRepository _employeeRepository = Mock.Of<IEmployeeRepository>();

        public EmployeeServiceTest()
        {
            _employeeService = new EmployeeService(_employeeRepository);
        }
                
        [Fact]
        public async Task test_create_creates_employee()
        {
            var dto = GetDto();
            await _employeeService.Create(dto);
            Mock.Get(_employeeRepository).Verify(x => x.Create(It.Is<Employee>(y
                => y.FirstName == dto.FirstName &&
                   y.LastName == dto.LastName &&
                   y.Address == dto.Address &&
                   y.Phone == dto.Phone &&
                   y.Salary == dto.Salary)));
        }

        [Fact]
        public async Task test_update_updates_employee()
        {
            var dto = GetDto();
            var employee = new Employee("Biraj", "Mainali", "Kathmandu", "934839483", 200000);
            await _employeeService.Update(employee, dto);
            Mock.Get(_employeeRepository).Verify(x => x.Update(It.Is<Employee>(y
                => y.FirstName == dto.FirstName &&
                   y.LastName == dto.LastName &&
                   y.Address == dto.Address &&
                   y.Phone == dto.Phone &&
                   y.Salary == dto.Salary)));
        }

        private static EmployeeDto GetDto()
        {
            const string firstName = "Hemant";
            const string lastName = "Panchal";
            const string address = "Mumbai";
            const string phone = "121211212122";
            const decimal salary = 20000M;
            return new EmployeeDto(firstName, lastName, address, phone, salary);
        }
    }
}
