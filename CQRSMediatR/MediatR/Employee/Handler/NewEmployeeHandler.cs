using CQRSMediatR.MediatR.Employee.Command;
using CQRSMediatR.Services.Interfaces;
using MediatR;

namespace CQRSMediatR.MediatR.Employee.Handler
{
    public class NewEmployeeHandler : IRequestHandler<NewEmployeeCommand, Entities.Employee>
    {
        private readonly IEmployeeService _employeeService;

        public NewEmployeeHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<Entities.Employee> Handle(NewEmployeeCommand request, CancellationToken cancellationToken)
            => await _employeeService.Create(request.EmployeeDto);
    }
}
