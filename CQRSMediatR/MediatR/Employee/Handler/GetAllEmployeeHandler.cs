using CQRSMediatR.MediatR.Employee.Query;
using CQRSMediatR.Repository.Generic;
using MediatR;

namespace CQRSMediatR.MediatR.Employee.Handler
{
    public class GetAllEmployeeHandler : IRequestHandler<Query.GetAllEmployeeQuery,List<Entities.Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;        
        public GetAllEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Entities.Employee>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        => await Task.Run(()=>_employeeRepository.GetAllAsync());
    }
}
