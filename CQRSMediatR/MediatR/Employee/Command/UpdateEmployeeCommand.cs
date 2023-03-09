using CQRSMediatR.Dto;
using MediatR;

namespace CQRSMediatR.MediatR.Employee.Command
{
    public class UpdateEmployeeCommand : IRequest
    {
        public Entities.Employee Employee { get; }
        public EmployeeDto Dto { get; }
        public UpdateEmployeeCommand(Entities.Employee employee, EmployeeDto dto)
        {
            Employee = employee;
            Dto = dto;
        }
    }
}
