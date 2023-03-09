using CQRSMediatR.Dto;
using MediatR;

namespace CQRSMediatR.MediatR.Employee.Command
{
    public class NewEmployeeCommand : IRequest<Entities.Employee>
    {
        public EmployeeDto EmployeeDto { get; }
        public NewEmployeeCommand(EmployeeDto employeeDto)
           => EmployeeDto = employeeDto;
    }
}
