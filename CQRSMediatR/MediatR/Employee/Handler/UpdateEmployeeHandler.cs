using CQRSMediatR.MediatR.Employee.Command;
using CQRSMediatR.Services.Interfaces;
using MediatR;

namespace CQRSMediatR.MediatR.Employee.Handler
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IEmployeeService _employeeService;

        public UpdateEmployeeHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        => await _employeeService.Update(request.Employee, request.Dto);

    }
}
