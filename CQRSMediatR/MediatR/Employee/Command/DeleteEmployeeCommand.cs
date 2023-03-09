using MediatR;

namespace CQRSMediatR.MediatR.Employee.Command
{
    public class DeleteEmployeeCommand : IRequest
    {
        public DeleteEmployeeCommand(Entities.Employee employee)
            => Employee = employee;
        public Entities.Employee Employee { get; }
    }
}
