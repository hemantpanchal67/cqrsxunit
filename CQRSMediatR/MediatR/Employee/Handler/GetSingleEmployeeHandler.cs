using CQRSMediatR.MediatR.Employee.Query;
using CQRSMediatR.Repository.Generic;
using MediatR;

namespace CQRSMediatR.MediatR.Employee.Handler
{
    public class GetSingleEmployeeHandler : IRequestHandler<GetSingleEmployeeQuery, Entities.Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public GetSingleEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Entities.Employee> Handle(GetSingleEmployeeQuery request, CancellationToken cancellationToken)
        => await Task.Run(() => _employeeRepository.FindOrThrow(request.Id), cancellationToken);

    }
}
