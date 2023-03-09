using CQRSMediatR.MediatR.Employee.Command;
using CQRSMediatR.Services.Interfaces;
using MediatR;

namespace CQRSMediatR.MediatR.Employee.Handler
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IEmployeeService _employeeService;

        public DeleteEmployeeHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        => await _employeeService.Remove(request.Employee);
    }
}
